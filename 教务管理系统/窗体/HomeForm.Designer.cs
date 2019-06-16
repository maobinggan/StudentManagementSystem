namespace 教务管理系统.界面
{
    partial class HomeForm
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
            this.btn_stuLogin = new System.Windows.Forms.Button();
            this.btn_teacherLogin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_stuLogin
            // 
            this.btn_stuLogin.Location = new System.Drawing.Point(147, 151);
            this.btn_stuLogin.Name = "btn_stuLogin";
            this.btn_stuLogin.Size = new System.Drawing.Size(75, 23);
            this.btn_stuLogin.TabIndex = 0;
            this.btn_stuLogin.Text = "学生登录";
            this.btn_stuLogin.UseVisualStyleBackColor = true;
            this.btn_stuLogin.Click += new System.EventHandler(this.Btn_stuLogin_Click);
            // 
            // btn_teacherLogin
            // 
            this.btn_teacherLogin.Location = new System.Drawing.Point(268, 151);
            this.btn_teacherLogin.Name = "btn_teacherLogin";
            this.btn_teacherLogin.Size = new System.Drawing.Size(75, 23);
            this.btn_teacherLogin.TabIndex = 1;
            this.btn_teacherLogin.Text = "教师登录";
            this.btn_teacherLogin.UseVisualStyleBackColor = true;
            this.btn_teacherLogin.Click += new System.EventHandler(this.Btn_teacherLogin_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(243, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "学号/教师工号：";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 283);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_teacherLogin);
            this.Controls.Add(this.btn_stuLogin);
            this.Name = "HomeForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_stuLogin;
        private System.Windows.Forms.Button btn_teacherLogin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

