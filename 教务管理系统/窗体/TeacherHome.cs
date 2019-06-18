using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;
using 教务管理系统.BEAN;
using 教务管理系统.DAO;

namespace 教务管理系统.窗体
{
    public partial class TeacherHome : Skin_Mac
    {
        /// <summary>
        /// 当前登录的教师信息
        /// </summary>
        TeacherBean teacher = null;

        /// <summary>
        /// 前一个窗体对象
        /// </summary>
        Form preForm = null;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="preForm"></param>
        public TeacherHome(TeacherBean teacher, Form preForm)
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
            this.teacher = teacher;
            this.preForm = preForm;
            skinLabel1.Text = "[姓名] " + teacher.Name ;
            skinLabel2.Text ="[教工编号] "+ teacher.TCode;
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

        /// <summary>
        /// 点击进入成绩录入界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_inputScore_Click(object sender, EventArgs e)
        {
            new InputScoreForm(this.teacher).Show();
        }

        /// <summary>
        /// 点击进入查看所有学生信息窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_showAllStu_Click(object sender, EventArgs e)
        {
            new ShowEducationProgramForm().Show();
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
