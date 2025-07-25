namespace minecraftServer_snyc_client_UWP_
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.Location = new Point(113, 265);
            label1.Name = "label1";
            label1.Size = new Size(226, 23);
            label1.TabIndex = 0;
            label1.Text = "@Designed and Crafted by Wu Ming";
            label1.Click += label1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(126, 21);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "快速同步mod模式";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 39);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(111, 21);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "服务器模糊搜索";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 3;
            label2.Text = "同步服务器地址";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.ForeColor = SystemColors.AppWorkspace;
            textBox1.Location = new Point(12, 96);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "192.168.1.1";
            // 
            // textBox2
            // 
            textBox2.ForeColor = SystemColors.ScrollBar;
            textBox2.Location = new Point(12, 142);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(70, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "6730";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 55);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 6;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(203, 227);
            button1.Name = "button1";
            button1.Size = new Size(65, 31);
            button1.TabIndex = 7;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(274, 227);
            button2.Name = "button2";
            button2.Size = new Size(65, 31);
            button2.TabIndex = 8;
            button2.Text = "应用";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 122);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 9;
            label4.Text = "端口";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 168);
            label5.Name = "label5";
            label5.Size = new Size(72, 17);
            label5.TabIndex = 10;
            label5.Text = "mod仓库ID";
            // 
            // textBox3
            // 
            textBox3.ForeColor = SystemColors.ScrollBar;
            textBox3.Location = new Point(12, 188);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(171, 23);
            textBox3.TabIndex = 11;
            textBox3.Text = "仓库iD";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 297);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Name = "SettingsForm";
            Text = "设置";
            ResumeLayout(false);
            PerformLayout();

            
        }

        #endregion

        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
    }
}
