namespace minecraftServer_snyc_client_UWP_
{
    partial class mineraftServer_snyc
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
            progressBar1 = new ProgressBar();
            textBox1 = new TextBox();
            button1 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            label4 = new Label();
            button4 = new Button();
            label5 = new Label();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Enabled = false;
            progressBar1.Location = new Point(11, 364);
            progressBar1.Margin = new Padding(3, 3, 20, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(347, 26);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(11, 326);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(377, 29);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button1.Location = new Point(397, 326);
            button1.Name = "button1";
            button1.Size = new Size(60, 29);
            button1.TabIndex = 4;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(370, 8);
            button2.Name = "button2";
            button2.Size = new Size(83, 29);
            button2.TabIndex = 5;
            button2.Text = "软件设置";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.AppWorkspace;
            label2.Location = new Point(8, 8);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(233, 17);
            label2.TabIndex = 6;
            label2.Text = "当前服务器：server.cooode.online:4012";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Location = new Point(8, 25);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(233, 17);
            label3.TabIndex = 7;
            label3.Text = "当前服务器：server.cooode.online:4012";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button3.Location = new Point(365, 364);
            button3.Name = "button3";
            button3.Size = new Size(92, 26);
            button3.TabIndex = 8;
            button3.Text = "开始同步";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonShadow;
            label4.Location = new Point(8, 42);
            label4.Name = "label4";
            label4.Size = new Size(112, 17);
            label4.TabIndex = 10;
            label4.Text = "当前MOD仓库ID：";
            label4.Click += label4_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(370, 43);
            button4.Name = "button4";
            button4.Size = new Size(84, 29);
            button4.TabIndex = 11;
            button4.Text = "查询仓库";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonShadow;
            label5.Location = new Point(8, 59);
            label5.Name = "label5";
            label5.Size = new Size(150, 17);
            label5.TabIndex = 12;
            label5.Text = "当前mineraft版本：1.20.1";
            label5.Click += label5_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ActiveCaption;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.CausesValidation = false;
            richTextBox1.Location = new Point(463, 8);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(344, 382);
            richTextBox1.TabIndex = 13;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Right;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(463, 8);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(346, 383);
            label1.TabIndex = 0;
            label1.Text = "current no search mineraft server online....\r\n";
            label1.TextAlign = ContentAlignment.TopRight;
            label1.Click += label1_Click;
            // 
            // mineraftServer_snyc
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 399);
            Controls.Add(richTextBox1);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "mineraftServer_snyc";
            Padding = new Padding(8);
            Text = "mineraftMod_snyc";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar progressBar1;
        private TextBox textBox1;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Button button3;
        private Label label4;
        private Button button4;
        private Label label5;
        private RichTextBox richTextBox1;
        private Label label1;
    }
}
