using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 教务管理系统.BEAN;
using 教务管理系统.DAO;

namespace 教务管理系统.窗体
{
    public partial class TeacherHome : Form
    {
        TeacherBean teacher = null;
        Form preForm = null;

        public TeacherHome(TeacherBean teacher, Form preForm)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.preForm = preForm;

            label1.Text = "[当前教师登录] 姓名:" + teacher.Name + " 教工编号:" + teacher.TCode;
        }

        /// <summary>
        /// 进入开班界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_openCourse_Click(object sender, EventArgs e)
        {
            new OpenCourseForm(this.teacher).Show();
        }

        private void btn_inputScore_Click(object sender, EventArgs e)
        {
            new InputScoreForm(this.teacher).Show();
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.preForm.Show();
            this.Close();
        }
    }
}
