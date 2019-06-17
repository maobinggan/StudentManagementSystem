namespace 教务管理系统.界面
{
    partial class StudentHomeForm
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
            this.btn_preSelect = new System.Windows.Forms.Button();
            this.btn_formalSelect = new System.Windows.Forms.Button();
            this.dgv_allCourse = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_myPlanCourse = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_myPlanCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_preSelect
            // 
            this.btn_preSelect.Location = new System.Drawing.Point(92, 99);
            this.btn_preSelect.Name = "btn_preSelect";
            this.btn_preSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_preSelect.TabIndex = 0;
            this.btn_preSelect.Text = "预选课";
            this.btn_preSelect.UseVisualStyleBackColor = true;
            this.btn_preSelect.Click += new System.EventHandler(this.Btn_preSelect_Click);
            // 
            // btn_formalSelect
            // 
            this.btn_formalSelect.Location = new System.Drawing.Point(236, 99);
            this.btn_formalSelect.Name = "btn_formalSelect";
            this.btn_formalSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_formalSelect.TabIndex = 1;
            this.btn_formalSelect.Text = "正式选课";
            this.btn_formalSelect.UseVisualStyleBackColor = true;
            this.btn_formalSelect.Click += new System.EventHandler(this.Btn_formalSelect_Click);
            // 
            // dgv_allCourse
            // 
            this.dgv_allCourse.AllowUserToAddRows = false;
            this.dgv_allCourse.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_allCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_allCourse.Location = new System.Drawing.Point(15, 177);
            this.dgv_allCourse.Name = "dgv_allCourse";
            this.dgv_allCourse.RowHeadersVisible = false;
            this.dgv_allCourse.RowTemplate.Height = 23;
            this.dgv_allCourse.Size = new System.Drawing.Size(837, 149);
            this.dgv_allCourse.TabIndex = 2;
            this.dgv_allCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellContent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "[基本信息]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "可预选的课程列表(2019年第3学期)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "我已选的预选课程";
            // 
            // dgv_myPlanCourse
            // 
            this.dgv_myPlanCourse.AllowUserToAddRows = false;
            this.dgv_myPlanCourse.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_myPlanCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_myPlanCourse.Location = new System.Drawing.Point(15, 383);
            this.dgv_myPlanCourse.Name = "dgv_myPlanCourse";
            this.dgv_myPlanCourse.RowHeadersVisible = false;
            this.dgv_myPlanCourse.RowTemplate.Height = 23;
            this.dgv_myPlanCourse.Size = new System.Drawing.Size(837, 251);
            this.dgv_myPlanCourse.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(813, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "注销";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "[专业信息]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "[培养方案]";
            // 
            // StudentHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 667);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_myPlanCourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_allCourse);
            this.Controls.Add(this.btn_formalSelect);
            this.Controls.Add(this.btn_preSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StudentHomeForm";
            this.Text = "SelectCourse";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_allCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_myPlanCourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_preSelect;
        private System.Windows.Forms.Button btn_formalSelect;
        private System.Windows.Forms.DataGridView dgv_allCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_myPlanCourse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}