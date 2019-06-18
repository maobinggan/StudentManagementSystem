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
    public partial class CountScoreForm : Skin_Mac
    {
        public CourseClassBean CourseClass = null;
        public CountScoreForm(CourseClassBean CourseClass)
        {

            InitializeComponent();
            this.CourseClass = CourseClass;
            label1.Text = "成绩录入:";

            ShowScoreInput();
            ShowScoreCount();
        }

        /// <summary>
        /// 显示成绩统计界面
        /// </summary>
        void ShowScoreCount()
        {
            ClassStudentDao classStudentDao = new ClassStudentDao();
            StudentDao studentDaoDao = new StudentDao();
            List<ClassStudentBean> classStudentList = classStudentDao.FindListById(new ClassStudentBean(CourseClass.Id, 0, 0, 0, 0, 0));
            if (classStudentList.Count == 0) return;
            //计算平均分、最高分、最低分、分段统计
            int stuId_MaxScore = classStudentList[0].Student_Id;
            int stuId_MinScore = classStudentList[0].Student_Id;
            int maxScore = classStudentList[0].Score;
            int minScore = classStudentList[0].Score;
            float avgScore = 0;
            int 及格人数 = 0;
            int 不及格人数 = 0;
            int 九十分及以上人数 = 0;

            foreach (ClassStudentBean bean in classStudentList)
            {
                if (bean.Score > maxScore)
                {
                    maxScore = bean.Score;
                    stuId_MaxScore = bean.Student_Id;
                }
                if (bean.Score < minScore)
                {
                    minScore = bean.Score;
                    stuId_MinScore = bean.Student_Id;
                }
                if (bean.Score >= 90)
                {
                    九十分及以上人数++;
                }
                else if (bean.Score >= 60)
                {
                    及格人数++;
                }
                else
                {
                    不及格人数++;
                }

                avgScore += bean.Score;
            }
            avgScore = avgScore / classStudentList.Count;

            //打印
            StudentBean stu_maxScore = studentDaoDao.FindById(new StudentBean(stuId_MaxScore));
            StudentBean stu_minScore = studentDaoDao.FindById(new StudentBean(stuId_MinScore));
            label3.Text = "班级平均分 : " + avgScore;
            label4.Text = "班级最高分 : " + maxScore + "(" + stu_maxScore.Name + ")";
            label5.Text = "班级最低分 : " + minScore + "(" + stu_minScore.Name + ")"; ;
            label6.Text = "各分段统计 ：不及格人数= " + 不及格人数 + " 及格人数= " + 及格人数 + " 九十分及以上人数= " + 九十分及以上人数;
        }

        /// <summary>
        /// 显示成绩录入界面
        /// </summary>
        void ShowScoreInput()
        {
            string sqlStr = "SELECT [class_student].[Id] AS 'ID',[course_class].[Id]AS '开班ID',[student].[scode] AS '学号',[student].[Name] AS '姓名' ,[course].[Cname] AS '课程名',[course].[Number] AS '课程编号' ,[teacher].[Name] AS '任课老师' ,[class_student].Gpa_score AS '平时成绩' ,[class_student].Paper_score AS '考试成绩',[class_student].Practice_score AS '实践成绩',[class_student].Score AS '总成绩'FROM [class_student],[student],[course],[course_class],[teacher] WHERE[class_student].[Student_id] =[student].[id] AND[class_student].[course_class_id] =[course_class].[id] AND[course_class].[course_id] =[course].[id] AND[course_class].Teacher_id =[teacher].Id AND [course_class].[Id]=" + CourseClass.Id;
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dataGridView1.DataSource = dataTable;
            }
        }


        /// <summary>
        /// 监听单元格事件：值修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCell_ValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int classStudentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());//获取焦点触发行的第1个值
            ClassStudentDao DAO = new ClassStudentDao();
            ClassStudentBean classStudent = DAO.FindById(new ClassStudentBean(classStudentId));
            if (e.ColumnIndex < 7 || e.ColumnIndex > 10) { return; }

            classStudent.Id = Convert.ToInt32(classStudentId);
            switch (e.ColumnIndex)
            {
                case 7://平时表现成绩
                    classStudent.Gpa_Score = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString()); //获取当前点击的活动单元格的值
                    break;
                case 8://理论考试成绩
                    classStudent.Paper_Score = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
                    break;
                case 9://实践考核成绩
                    classStudent.Practice_Score = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
                    break;
                case 10://总评成绩
                    classStudent.Score = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
                    break;
            }
            DAO.UpdateById(classStudent);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ShowScoreCount();
        }
    }
}
