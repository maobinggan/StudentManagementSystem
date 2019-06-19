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
            this.button1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox1 = new CCWin.SkinControl.SkinComboBox();
            this.txButton1 = new TX.Framework.WindowUI.Controls.TXButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(347, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // skinComboBox1
            // 
            this.skinComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox1.FormattingEnabled = true;
            this.skinComboBox1.Items.AddRange(new object[] {
            "开班",
            "录入/统计成绩",
            "查看学生培养方案"});
            this.skinComboBox1.Location = new System.Drawing.Point(134, 74);
            this.skinComboBox1.Name = "skinComboBox1";
            this.skinComboBox1.Size = new System.Drawing.Size(121, 22);
            this.skinComboBox1.TabIndex = 8;
            this.skinComboBox1.Text = "请选择";
            this.skinComboBox1.WaterText = "";
            // 
            // txButton1
            // 
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(281, 74);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(76, 23);
            this.txButton1.TabIndex = 9;
            this.txButton1.Text = "确定";
            this.txButton1.UseVisualStyleBackColor = true;
            this.txButton1.Click += new System.EventHandler(this.TxButton1_Click);
            // 
            // TeacherHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(419, 221);
            this.Controls.Add(this.txButton1);
            this.Controls.Add(this.skinComboBox1);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.gifBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TeacherHome";
            this.Text = "教师主页";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TXButton button1;
        private CCWin.SkinControl.GifBox gifBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinComboBox skinComboBox1;
        private TXButton txButton1;
    }
}