using System.Windows.Forms;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace minecraftServer_snyc_client_UWP_
{

    public partial class mineraftServer_snyc : Form
    {
        private UserSettings userSettings;

        private programInfomation_current currentInfo = programInfomation_current.Instance;

        private static List<string> modList = new List<string>();
        public mineraftServer_snyc()
        {
            InitializeComponent();
            userSettings = UserSettings.Load();
            RefreshLabels();
            textBox1.Text = userSettings.path_mod ?? string.Empty;

            // ������־�¼�
            Logger.OnLog += Logger_OnLog;
        }

        private void Logger_OnLog(string message)
        {
            AppendLog(message);
        }

        private void AppendLog(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AppendLog), text);
                return;
            }

            richTextBox1.AppendText(text + Environment.NewLine);
            richTextBox1.ScrollToCaret();

        }
        private void RefreshLabels()
        {


            label2.Text = $"��ǰmodĿ¼: {userSettings.path_mod}";
            label3.Text = $"��ǰ��������ַ: http://{userSettings.server_destnation}:{userSettings.port}/";
            label4.Text = $"��ǰMOD�ֿ�id: {userSettings.path_server_modID}";
            textBox1.Text = userSettings.path_mod;


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            progressBar1.Location = new Point(10, this.ClientSize.Height - progressBar1.Height - 20);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                    userSettings.path_mod = textBox1.Text;
                    userSettings.Save();
                    Logger.Log($"The mod repository is saved: {textBox1.Text}");


                    currentInfo.application_log += $"The mod repository is saved:{textBox1.Text}\n";
                }
            }

            // ����������֤
            loaddingFilewindows loaddingFilewindows = new loaddingFilewindows(textBox1.Text);

            //��ʼ�����ļ�
            loaddingFilewindows.Show();
            loaddingFilewindows.Shown += (s, args) =>
            {
                // �ڼ�����ɺ�ˢ�±�ǩ
                RefreshLabels();
            };
            loaddingFilewindows.FormClosed += (s, args) =>
            {
                // ���ڹرպ�ˢ�±�ǩ
                RefreshLabels();
                textBox1.Text = userSettings.path_mod;
            };


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            userSettings.path_mod = textBox1.Text;
            userSettings.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.SettingsChanged += (s, args) =>
                {
                    userSettings = UserSettings.Load();
                    RefreshLabels();
                };
                settingsForm.ShowDialog(this);
                // �����ô��ڹرպ�ˢ�±�ǩ
                settingsForm.FormClosed += (s, args) =>
                {
                    RefreshLabels();
                };
                settingsForm.Shown += (s, args) =>
                {
                    // �����ô�����ʾ��ˢ�±�ǩ
                    RefreshLabels();
                };
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private static async Task mod_request(string server_ip, string port,string mod_id,bool http_modthes)
        {
            var client = new HttpClient();
            string url = $"{(http_modthes ? "https" : "http")}://{server_ip}:{port}/modlist_id/{mod_id}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                JObject result = JObject.Parse(jsonResponse);

                Console.WriteLine("mod_id: " + result["mod_id"]);
                Console.WriteLine("mod_list:");
                foreach (var item in result["mod_list"])
                {
                    Console.WriteLine(" - " + item);
                }
                Console.WriteLine("status: " + result["status"]);
                Logger.Log($"Mod warehouse: {result["status"]}��{result["mod_id"]}");
                modList.Clear();
                foreach (string mod in result["mod_list"])
                {
                    Logger.Log($"{mod}");
                    modList.Add(mod);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("����ʧ��: " + ex.Message);
                Logger.Log($"If the data request fails, check whether the server and repository ID are correct,ID:{mod_id}");
                MessageBox.Show("�ֿ�ID��������ص�ַ�Լ��˿ڴ���", "��ѯ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private async void button3_Click_1(object sender, EventArgs e)
        {
            var downloader = new ModDownloader();

            await mod_request(userSettings.server_destnation, userSettings.port, userSettings.path_server_modID, false);
            
            try
            {
                Logger.Log("start mod snyc from server");
                await downloader.DownloadModsAsync(modList, progressBar1); // ������� ProgressBar �ؼ�
            }
            finally
            {

            }
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await mod_request(userSettings.server_destnation,userSettings.port,userSettings.path_server_modID,false);
        }
    }

    public class ModDownloader
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private UserSettings userSettings;

        
        /// <summary>
        /// �첽���� mod �б������½�����
        /// </summary>
        /// <param name="result">���� mod_list ���ֵ�</param>
        /// <param name="progressBar">Ҫ���µ� ProgressBar �ؼ�</param>
        /// <returns></returns>
        public async Task DownloadModsAsync(List<string> result, ProgressBar progressBar)
        {
            userSettings = UserSettings.Load();

            int total = result.Count;

            Logger.Log($"mod ����:{result.Count}");

            // �� UI �߳��г�ʼ��������
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Minimum = 0;
                    progressBar.Maximum = total;
                    progressBar.Value = 0;
                });
            }
            else
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = total;
                progressBar.Value = 0;
            }

            int sussesc = 0;
            int failt = 0;

            for (int i = 0; i < result.Count; i++)
            {
                string mod = result[i];
                
                string downloadUrl = $"http://{userSettings.server_destnation}:{userSettings.port}/mod_request_snyc/{userSettings.path_server_modID}/{mod}.jar"; // �滻Ϊ��ʵ��ַ
                Logger.Log($"http://{userSettings.server_destnation}:{userSettings.port}/mod_request_snyc/{userSettings.path_server_modID}/{mod}.jar");
                try
                {
                    Console.WriteLine($"��ʼ����: {mod}");
                    HttpResponseMessage response = await httpClient.GetAsync(downloadUrl);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"�������: {mod}����С: {content.Length} �ֽ�");
                    Logger.Log($"�������: {mod}����С: {content.Length} �ֽ�");
                    sussesc++;
                    // ���½������������� UI �߳��в�����
                    if (progressBar.InvokeRequired)
                    {
                        progressBar.Invoke((MethodInvoker)delegate
                        {
                            progressBar.Value = i + 1;
                        });
                    }
                    else
                    {
                        progressBar.Value = i + 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"����ʧ��: {mod}������: {ex.Message}");
                    Logger.Log($"����ʧ��: {mod}������: {ex.Message}");
                    // ��ѡ����¼���󵫼�����һ��
                    failt++;
                }

                // ��ѡ��ÿ�����غ���ͣ 100ms
                await Task.Delay(100);
            }

            MessageBox.Show($"ͬ���ɹ�:{sussesc}��ͬ��ʧ��:{failt}", "ͬ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
