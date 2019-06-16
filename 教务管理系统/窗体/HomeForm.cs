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
using 教务管理系统.窗体;

namespace 教务管理系统.界面
{
    public partial class HomeForm : Form
    {
        /// <summary>
        /// 在OnActivated事件中为输入框获取焦点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            textBox1.Focus();
        }
        public HomeForm()
        {
            InitializeComponent();
        }

        private void Btn_stuLogin_Click(object sender, EventArgs e)
        {
            //学号检查
            StudentBean student = new StudentDao().FindBySCode(textBox1.Text);
            if (student != null)
            {
                new StudentHomeForm(student,this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("错误！不存在此学号");
            }

        }

        private void Btn_teacherLogin_Click(object sender, EventArgs e)
        {
            //教师工号
            TeacherBean teacher = new TeacherDao().FindByTCode(textBox1.Text);
            if (teacher != null)
            {
                new TeacherHome(teacher,this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("错误！不存在此教师工号");
            }
        }
    }
}
