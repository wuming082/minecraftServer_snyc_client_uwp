using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecraftServer_snyc_client_UWP_
{
    public partial class SettingsForm : Form
    {
        private UserSettings userSettings;
        public event EventHandler SettingsChanged; // �����¼�
        private programInfomation_current currentInfo = programInfomation_current.Instance;

        public SettingsForm()
        {
            InitializeComponent();
            userSettings = UserSettings.Load();
            if(userSettings.server_destnation == "")
            {
                textBox1.ForeColor = textBox1.ForeColor = Color.LightGray; // ��ǳ�Ļ�ɫ;
                textBox2.ForeColor = textBox1.ForeColor = Color.LightGray; // ��ǳ�Ļ�ɫ;
                textBox3.ForeColor = textBox1.ForeColor = Color.LightGray; // ��ǳ�Ļ�ɫ;

                textBox1.Text = "192.168.1.1";
                textBox2.Text = "6730";
                textBox3.Text = "modID";
            }
            else
            {
                textBox1.ForeColor = Color.Black; // �ָ�Ϊ��ɫ
                textBox2.ForeColor = Color.Black; // �ָ�Ϊ��ɫ
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

        // "Ӧ��"��ť����������
        private void button2_Click(object sender, EventArgs e)
        {
            userSettings.server_destnation = textBox1.Text;
            userSettings.port = textBox2.Text;
            userSettings.path_server_modID = textBox3.Text;
            userSettings.Save();
            Logger.Log($"Set saved: server address {userSettings.server_destnation}, port: {userSettings.port}, MOD warehouse ID {userSettings.path_server_modID}");

            SettingsChanged?.Invoke(this, EventArgs.Empty); // �����¼�
            MessageBox.Show("�����ѱ��棡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            currentInfo.application_log += $"Set saved: server address {userSettings.server_destnation}, port: {userSettings.port}, MOD warehouse ID {userSettings.path_server_modID}\n";
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            userSettings.server_destnation = textBox1.Text;
            userSettings.port = textBox2.Text;
            userSettings.path_server_modID = textBox3.Text;
            userSettings.Save();
            SettingsChanged?.Invoke(this, EventArgs.Empty); // �����¼�


            // ƴ�������ķ����� URL�����ж˿ڣ�
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

                MessageBox.Show(isOnline ? "����������" : "������������\n��ȷ����ķ�������ַ�Լ��˿ں�������ȷ", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
