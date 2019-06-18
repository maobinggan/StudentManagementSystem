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
using 教务管理系统.BEAN;
using 教务管理系统.DAO;

namespace 教务管理系统.窗体
{
    public partial class InputScoreForm : Skin_Mac
    {
        public TeacherBean teacher = null;
        public InputScoreForm(TeacherBean teacherBean)
        {
            InitializeComponent();
            this.teacher = teacherBean;
            label2.Text = "[当前教师登录] 姓名:" + teacher.Name + " 教工编号:" + teacher.TCode;
            Show();
        }

        /// <summary>
        /// 展示datagridview
        /// </summary>
        void Show()
        {
            string sqlStr = "SELECT [course_class].[id] AS'开班ID',[course].[Number] AS'课程编号',[course].[Cname] AS '课程名称',[teacher].[Name] AS '任课教师' FROM [teacher],[course_class],[course] WHERE[teacher].[Id] =[course_class].[Teacher_id] AND[course].[Id] =[course_class].[course_id] AND [teacher].[Id]=" + teacher.Id;
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView2的数据源
                this.skinDataGridView1.DataSource = dataTable;
            }
            //添加一列按钮，按钮的行数取决于DataGridView的行数
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "btnChooseCourse";                  //列名
            col_Btn.HeaderText = "操作";                       //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "选择此班级";  //按钮上显示的文字
            this.skinDataGridView1.Columns.Add(col_Btn);          //添加列
        }

        /// <summary>
        ///  监听DataGridView列按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "btnChooseCourse")
            {
                int courseClassId = (int)skinDataGridView1.Rows[e.RowIndex].Cells[1].Value;
                CourseClassBean courseClass = new CourseClassDao().FindById(new CourseClassBean(courseClassId));
                if (courseClass != null)
                {
                    new CountScoreForm(courseClass).Show();
                }
            }
        }

    }
}
