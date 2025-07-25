namespace minecraftServer_snyc_client_UWP_
{
    partial class loaddingFilewindows
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private static UserSettings userSettings;

        private programInfomation_current currentInfo = programInfomation_current.Instance;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 

        private string _filePath_mod = string.Empty;// 存储mod文件路径

        public loaddingFilewindows(string _filepath)
        {
            InitializeComponent();
            this._filePath_mod = _filepath;
            this.Shown += new System.EventHandler(this.loaddingFilewindows_Shown);
            userSettings = UserSettings.Load();
        }

        // 窗口加载事件处理程序
        private async void loaddingFilewindows_Shown(object sender, EventArgs e)
        {
            // 在这里可以添加加载环境信息的逻辑
            // 例如，读取文件、初始化设置等
            label2.Text = $"{this._filePath_mod}";
            progressBar1.Style = ProgressBarStyle.Marquee; // 设置为不确定进度条样式

            // 模拟等待 1 秒（可选）
            await Task.Delay(1000);

            // 异步执行查找操作
            bool result = await Task.Run(() => file_verify_task(this._filePath_mod));

            if (result)
            {
                Logger.Log($"{this._filePath_mod} The local repository is configured");

                currentInfo.application_log += $"{this._filePath_mod} The local repository is configured\n";
                this.Close();
            }
            else
            {
                Logger.Log("The mods directory was not found. Please check if the path is correct");

                currentInfo.application_log += "The mods directory was not found. Please check if the path is correct\n";
                MessageBox.Show("未找到mods目录，请检查路径是否正确。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private bool file_verify_task(string dest_mod_file_path)
        {
            return FindModPath(new DirectoryInfo(dest_mod_file_path), "mods");
        }

       

        private static bool FindModPath(DirectoryInfo dirInfo, string targetDirName)
        {
            try
            {
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    // 如果当前目录名匹配目标目录名
                    if (subDir.Name.Equals(targetDirName, StringComparison.OrdinalIgnoreCase))
                    {
                        userSettings.path_mod = subDir.FullName;
                        userSettings.Save();
                        return true;
                    }

                    // 递归查找子目录
                    if (FindModPath(subDir, targetDirName))
                    {
                        return true; // 如果子目录中找到，返回 true
                    }
                    
                    // 注意：这里没有 return，会继续遍历下一个子目录
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
                return false;
            }

            return false; // 所有子目录都遍历完了，没找到
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 99);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(340, 23);
            progressBar1.TabIndex = 0;
            progressBar1.Click += progressBar1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 1;
            label1.Text = "加载环境信息";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(0, 17);
            label2.TabIndex = 2;
            // 
            // loaddingFilewindows
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 134);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Name = "loaddingFilewindows";
            Text = "Loading";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
        private Label label2;
    }
}