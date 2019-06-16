namespace 教务管理系统.窗体
{
    partial class TeacherHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_openCourse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_inputScore = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_showAllStu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_openCourse
            // 
            this.btn_openCourse.Location = new System.Drawing.Point(125, 56);
            this.btn_openCourse.Name = "btn_openCourse";
            this.btn_openCourse.Size = new System.Drawing.Size(179, 23);
            this.btn_openCourse.TabIndex = 0;
            this.btn_openCourse.Text = "根据预选课情况进行开班";
            this.btn_openCourse.UseVisualStyleBackColor = true;
            this.btn_openCourse.Click += new System.EventHandler(this.Btn_openCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btn_inputScore
            // 
            this.btn_inputScore.Location = new System.Drawing.Point(125, 115);
            this.btn_inputScore.Name = "btn_inputScore";
            this.btn_inputScore.Size = new System.Drawing.Size(179, 23);
            this.btn_inputScore.TabIndex = 2;
            this.btn_inputScore.Text = "录入/统计成绩";
            this.btn_inputScore.UseVisualStyleBackColor = true;
            this.btn_inputScore.Click += new System.EventHandler(this.btn_inputScore_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_showAllStu
            // 
            this.btn_showAllStu.Location = new System.Drawing.Point(125, 169);
            this.btn_showAllStu.Name = "btn_showAllStu";
            this.btn_showAllStu.Size = new System.Drawing.Size(179, 23);
            this.btn_showAllStu.TabIndex = 4;
            this.btn_showAllStu.Text = "查看所有本科人才的培养方案";
            this.btn_showAllStu.UseVisualStyleBackColor = true;
            this.btn_showAllStu.Click += new System.EventHandler(this.Btn_showAllStu_Click);
            // 
            // TeacherHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 252);
            this.Controls.Add(this.btn_showAllStu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_inputScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_openCourse);
            this.Name = "TeacherHome";
            this.Text = "TeacherHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_openCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_inputScore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_showAllStu;
    }
}