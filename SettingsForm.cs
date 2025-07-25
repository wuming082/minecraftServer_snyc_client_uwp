using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecraftServer_snyc_client_UWP_
{
    public partial class SettingsForm : Form
    {
        private UserSettings userSettings;
        public event EventHandler SettingsChanged; // 新增事件
        private programInfomation_current currentInfo = programInfomation_current.Instance;

        public SettingsForm()
        {
            InitializeComponent();
            userSettings = UserSettings.Load();
            if(userSettings.server_destnation == "")
            {
                textBox1.ForeColor = textBox1.ForeColor = Color.LightGray; // 更浅的灰色;
                textBox2.ForeColor = textBox1.ForeColor = Color.LightGray; // 更浅的灰色;
                textBox3.ForeColor = textBox1.ForeColor = Color.LightGray; // 更浅的灰色;

                textBox1.Text = "192.168.1.1";
                textBox2.Text = "6730";
                textBox3.Text = "modID";
            }
            else
            {
                textBox1.ForeColor = Color.Black; // 恢复为黑色
                textBox2.ForeColor = Color.Black; // 恢复为黑色
                textBox3.ForeColor = Color.Black;

                textBox1.Text = userSettings.server_destnation;
                textBox2.Text = userSettings.port;
                textBox3.Text = userSettings.path_server_modID;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // "应用"按钮，保存设置
        private void button2_Click(object sender, EventArgs e)
        {
            userSettings.server_destnation = textBox1.Text;
            userSettings.port = textBox2.Text;
            userSettings.path_server_modID = textBox3.Text;
            userSettings.Save();
            Logger.Log($"Set saved: server address {userSettings.server_destnation}, port: {userSettings.port}, MOD warehouse ID {userSettings.path_server_modID}");

            SettingsChanged?.Invoke(this, EventArgs.Empty); // 触发事件
            MessageBox.Show("设置已保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            currentInfo.application_log += $"Set saved: server address {userSettings.server_destnation}, port: {userSettings.port}, MOD warehouse ID {userSettings.path_server_modID}\n";
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            userSettings.server_destnation = textBox1.Text;
            userSettings.port = textBox2.Text;
            userSettings.path_server_modID = textBox3.Text;
            userSettings.Save();
            SettingsChanged?.Invoke(this, EventArgs.Empty); // 触发事件


            // 拼接完整的服务器 URL（如有端口）
            string url = userSettings.server_destnation;
            if (!string.IsNullOrWhiteSpace(userSettings.port))
            {
                url = $"http://{url}:{userSettings.port}/server_status";
            }

            button1.Enabled = false;
            var oldText = button1.Text;

            try
            {
                bool isOnline = await server_info.Online_verify(url);
                Logger.Log(isOnline ? $"Server {url} is online." : $"Server {url} is offline");

                MessageBox.Show(isOnline ? "服务器在线" : "服务器不在线\n请确认你的服务器地址以及端口号输入正确", "检测结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentInfo.application_log += isOnline ? $"Server {url} is online.\n" : $"Server {url} is offline\n";
            }
            finally
            {
                button1.Text = oldText;
                button1.Enabled = true;
            }
        }


    }


}
