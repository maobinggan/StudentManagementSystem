using TX.Framework.WindowUI.Controls;

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
            this.btn_openCourse = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_inputScore = new TX.Framework.WindowUI.Controls.TXButton();
            this.button1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.btn_showAllStu = new TX.Framework.WindowUI.Controls.TXButton();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // btn_openCourse
            // 
            this.btn_openCourse.Image = null;
            this.btn_openCourse.Location = new System.Drawing.Point(170, 67);
            this.btn_openCourse.Name = "btn_openCourse";
            this.btn_openCourse.Size = new System.Drawing.Size(179, 23);
            this.btn_openCourse.TabIndex = 0;
            this.btn_openCourse.Text = "根据预选课情况进行开班";
            this.btn_openCourse.UseVisualStyleBackColor = true;
            this.btn_openCourse.Click += new System.EventHandler(this.Btn_openCourse_Click);
            // 
            // btn_inputScore
            // 
            this.btn_inputScore.Image = null;
            this.btn_inputScore.Location = new System.Drawing.Point(170, 115);
            this.btn_inputScore.Name = "btn_inputScore";
            this.btn_inputScore.Size = new System.Drawing.Size(179, 23);
            this.btn_inputScore.TabIndex = 2;
            this.btn_inputScore.Text = "录入/统计成绩";
            this.btn_inputScore.UseVisualStyleBackColor = true;
            this.btn_inputScore.Click += new System.EventHandler(this.btn_inputScore_Click);
            // 
            // button1
            // 
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(365, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btn_showAllStu
            // 
            this.btn_showAllStu.Image = null;
            this.btn_showAllStu.Location = new System.Drawing.Point(170, 162);
            this.btn_showAllStu.Name = "btn_showAllStu";
            this.btn_showAllStu.Size = new System.Drawing.Size(179, 23);
            this.btn_showAllStu.TabIndex = 4;
            this.btn_showAllStu.Text = "查看所有本科人才的培养方案";
            this.btn_showAllStu.UseVisualStyleBackColor = true;
            this.btn_showAllStu.Click += new System.EventHandler(this.Btn_showAllStu_Click);
            // 
            // gifBox1
            // 
            this.gifBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox1.Image = global::教务管理系统.Properties.Resources.teacher;
            this.gifBox1.Location = new System.Drawing.Point(23, 49);
            this.gifBox1.Name = "gifBox1";
            this.gifBox1.Size = new System.Drawing.Size(92, 89);
            this.gifBox1.TabIndex = 5;
            this.gifBox1.Text = "gifBox1";
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(20, 153);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(69, 17);
            this.skinLabel1.TabIndex = 6;
            this.skinLabel1.Text = "skinLabel1";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(20, 179);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(69, 17);
            this.skinLabel2.TabIndex = 7;
            this.skinLabel2.Text = "skinLabel2";
            // 
            // TeacherHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 222);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.gifBox1);
            this.Controls.Add(this.btn_showAllStu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_inputScore);
            this.Controls.Add(this.btn_openCourse);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TeacherHome";
            this.Text = "教师主页";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private TXButton btn_openCourse;
        private TXButton btn_inputScore;
        private TXButton button1;
        private TXButton btn_showAllStu;
        private CCWin.SkinControl.GifBox gifBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
    }
}