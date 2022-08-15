namespace GT
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.helpProvider1.SetHelpString(this.button1, "开始翻译按钮，按下时翻译输入框中的按钮");
            this.button1.Location = new System.Drawing.Point(197, 369);
            this.button1.Name = "button1";
            this.helpProvider1.SetShowHelp(this.button1, true);
            this.button1.Size = new System.Drawing.Size(226, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "翻译";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.helpProvider1.SetHelpString(this.richTextBox1, "输出框，翻译结果输出");
            this.richTextBox1.Location = new System.Drawing.Point(8, 18);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.richTextBox1, true);
            this.richTextBox1.Size = new System.Drawing.Size(282, 203);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDoubleClick);
            // 
            // richTextBox2
            // 
            this.helpProvider1.SetHelpString(this.richTextBox2, "输入框，输入要翻译的内容");
            this.richTextBox2.Location = new System.Drawing.Point(4, 18);
            this.richTextBox2.Name = "richTextBox2";
            this.helpProvider1.SetShowHelp(this.richTextBox2, true);
            this.richTextBox2.Size = new System.Drawing.Size(279, 203);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            this.richTextBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox2_MouseDoubleClick);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(362, 428);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(225, 203);
            this.richTextBox3.TabIndex = 0;
            this.richTextBox3.TabStop = false;
            this.richTextBox3.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "翻译次数：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.helpProvider1.SetHelpString(this.progressBar1, "进度条，显示翻译进度");
            this.progressBar1.Location = new System.Drawing.Point(15, 335);
            this.progressBar1.Name = "progressBar1";
            this.helpProvider1.SetShowHelp(this.progressBar1, true);
            this.progressBar1.Size = new System.Drawing.Size(567, 28);
            this.progressBar1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.helpProvider1.SetHelpString(this.button2, "取消按钮，取消翻译");
            this.button2.Location = new System.Drawing.Point(429, 369);
            this.button2.Name = "button2";
            this.helpProvider1.SetShowHelp(this.button2, true);
            this.button2.Size = new System.Drawing.Size(90, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpProvider1.SetHelpString(this.label4, "显示提示与信息");
            this.label4.Location = new System.Drawing.Point(123, 338);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(347, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "错误";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // button3
            // 
            this.helpProvider1.SetHelpString(this.button3, "复制键，复制输出框中的内容至剪贴板");
            this.button3.Location = new System.Drawing.Point(303, 270);
            this.button3.Name = "button3";
            this.helpProvider1.SetShowHelp(this.button3, true);
            this.button3.Size = new System.Drawing.Size(279, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "复制";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.helpProvider1.SetHelpString(this.button4, "粘贴键，将剪贴板内容粘贴至输入框");
            this.button4.Location = new System.Drawing.Point(15, 270);
            this.button4.Name = "button4";
            this.helpProvider1.SetShowHelp(this.button4, true);
            this.button4.Size = new System.Drawing.Size(279, 27);
            this.button4.TabIndex = 2;
            this.button4.Text = "粘贴";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Help;
            this.helpProvider1.SetHelpString(this.button5, "帮助按钮，显示帮助");
            this.button5.Location = new System.Drawing.Point(125, 370);
            this.button5.Name = "button5";
            this.helpProvider1.SetShowHelp(this.button5, true);
            this.button5.Size = new System.Drawing.Size(66, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "帮助";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.helpProvider1.SetHelpString(this.button6, "退出按钮，终止翻译并立刻强制退出");
            this.button6.Location = new System.Drawing.Point(521, 369);
            this.button6.Name = "button6";
            this.helpProvider1.SetShowHelp(this.button6, true);
            this.button6.Size = new System.Drawing.Size(61, 31);
            this.button6.TabIndex = 11;
            this.button6.Text = "退出";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(467, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "注：翻译时一行不能多于大约20-30个字，不然可能会少翻译一些内容";
            // 
            // numericUpDown1
            // 
            this.helpProvider1.SetHelpString(this.numericUpDown1, "翻译次数输入框，输入要翻译的次数");
            this.numericUpDown1.Location = new System.Drawing.Point(101, 303);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.helpProvider1.SetShowHelp(this.numericUpDown1, true);
            this.numericUpDown1.Size = new System.Drawing.Size(481, 25);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.helpProvider1.SetHelpString(this.checkBox1, "窗口置顶选择框，选择窗口是否置顶");
            this.checkBox1.Location = new System.Drawing.Point(15, 369);
            this.checkBox1.Name = "checkBox1";
            this.helpProvider1.SetShowHelp(this.checkBox1, true);
            this.checkBox1.Size = new System.Drawing.Size(104, 31);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "窗口置顶";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Location = new System.Drawing.Point(5, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 228);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(300, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 228);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "谷歌生草机";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

