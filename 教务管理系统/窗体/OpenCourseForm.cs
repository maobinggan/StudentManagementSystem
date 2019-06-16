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
    public partial class OpenCourseForm : Form
    {
        TeacherBean teacher = null;
        public OpenCourseForm(TeacherBean teacher)
        {
            this.teacher = teacher;
            InitializeComponent();
            label3.Text = "[当前教师登录] 姓名:" + teacher.Name + " 教工编号:" + teacher.TCode;
            ShowStuPlan();
            ShowMyOpenCourse();
        }

        /// <summary>
        /// 显示我的开班情况
        /// </summary>
        void ShowMyOpenCourse()
        {
            string sqlStr = "SELECT [course_class].[id] AS'开班ID',[course].[Number] AS'课程编号',[course].[Cname] AS '课程名称',[teacher].[Name] AS '任课教师',[course].[Score] AS '学分',[course].Tchour AS '理论总学时' FROM [teacher],[course_class],[course] WHERE[teacher].[Id] =[course_class].[Teacher_id] AND[course].[Id] =[course_class].[course_id] AND [teacher].[Id]=" + teacher.Id;
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView2的数据源
                this.dataGridView2.DataSource = dataTable;
            }
        }

        /// <summary>
        /// 显示学生预选情况
        /// </summary>
        void ShowStuPlan()
        {
            string sqlStr = "SELECT [course].[id]AS '课程ID',[course].[Number]AS '课程编号',[course].[Cname]AS '课程名' ,COUNT(course_id)AS '已选人数' FROM [plan_study_course] FULL JOIN[course] ON[plan_study_course].[course_id] =[course].[Id] GROUP BY[plan_study_course].[course_id] ,[course].[id],[course].[Number],[course].[Cname] ORDER BY[course].[Number]";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dataGridView1.DataSource = dataTable;
            }
            //添加一列按钮，按钮的行数取决于DataGridView的行数
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "btnOpenCourse";                            //列名
            col_Btn.HeaderText = "操作";                        //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "开班";        //按钮上显示的文字
            this.dataGridView1.Columns.Add(col_Btn);            //添加列
        }
        /// <summary>
        /// 点击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnOpenCourse")
            {//判断列名，点击的列是DataGridViewButtonColumn列


                int courseId = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                int pickedCount = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                if (pickedCount == 0)
                {
                    MessageBox.Show("开班失败！没有学生选择该课程！");
                    return;
                }
                //查:表[CourseClass]
                CourseClassBean courseClass = new CourseClassBean(3, courseId, 50, teacher.Id);
                CourseClassDao DAO = new CourseClassDao();
                if (DAO.FindByCourId_TeacherId(courseClass) != null)
                {
                    MessageBox.Show("开班失败！您已开设过该课程!");
                    return;
                }

                //增：表[CourseClass]
                if (DAO.Add(courseClass))
                {
                    ShowMyOpenCourse();
                    MessageBox.Show("开班成功!");
                }
            }
        }
    }
}
