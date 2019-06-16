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

namespace 教务管理系统.界面
{
    public partial class StudentHomeForm : Form
    {
        /// <summary>
        /// 当前登录的学生信息
        /// </summary>
        public StudentBean student;

        /// <summary>
        /// 当前登录的班级信息
        /// </summary>
        public ClassBean classBean;

        /// <summary>
        /// 当前登录的专业(方向)信息
        /// </summary>
        public MajorBean major;

        /// <summary>
        /// 当前登录的培养方案信息
        /// </summary>
        public EducationProgramBean educationProgram;


        /// <summary>
        /// 前一个窗体对象
        /// </summary>
        public Form preForm;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="student"></param>
        public StudentHomeForm(StudentBean student, Form preForm)
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮

            this.student = student;
            this.preForm = preForm;
            this.classBean = new ClassDao().FindById(new ClassBean(student.Class_Id));
            this.major = new MajorDao().FindById(new MajorBean(classBean.Major_id));
            this.educationProgram = new EducationProgramDao().FindByMajorId(new EducationProgramBean(null, null, null, 0, null, 0, 0, classBean.Major_id));

            label1.Text = "[姓  名]:" + student.Name + "  [学号]:" + student.SCode;
            label4.Text = "[专业名]:" + major.Name + " [班级名]:" + classBean.Name + " [培养方案名称]:" + educationProgram.Name;

            //ShowAllPlanCourse();
            //ShowMyPlanCourse();

        }

        /// <summary>
        /// 显示所有预选课程
        /// </summary>
        private void ShowAllPlanCourse()
        {
            String sqlStr = "SELECT [course].id AS '课程ID',[course].Number AS '课程编号',[cname] AS '课程名称',[Score] AS'学分',[Tlhour] AS '周学时' ,[category_course].Name AS '课程类别' ,[education_program].Name AS '培养方案'FROM[course],[curriculum],[category_course],[education_program] WHERE [curriculum].course_id = [course].id AND [curriculum].Category_id=[category_course].id AND [curriculum].Program_id= [education_program].id ORDER BY [course].Number";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dgv_allCourse.DataSource = null;
                this.dgv_allCourse.DataSource = dataTable;
            }
            //添加一列按钮，按钮的行数取决于DataGridView的行数
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "colBtn_preSelect";                          //列名
            col_Btn.HeaderText = "操作";                                //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "预选";                //按钮上显示的文字
            this.dgv_allCourse.Columns.Add(col_Btn);                    //添加列
        }
        /// <summary>
        /// 显示我已选的预选课程
        /// </summary>
        private void ShowMyPlanCourse()
        {
            String sqlStr = "SELECT [student].[scode]AS '学生学号', [student].[Name]AS '学生姓名',[course].[number]AS '课程编号',[course].[Cname]AS '课程名',[course].[score] AS '学分',[semester].[Name] AS '学期信息',[category_course].Name AS '课程类别' ,[education_program].Name AS '培养方案' FROM[course],[student],[semester],[plan_study_course],[curriculum],[category_course],[education_program] WHERE[student].[id]=[plan_study_course].[Student_id] AND[course].[id]=[plan_study_course].[course_id] AND[semester].[id]=[plan_study_course].[Semester_id] AND[curriculum].course_id = [course].id AND[curriculum].Category_id=[category_course].id AND[curriculum].Program_id= [education_program].id AND[plan_study_course].[Student_id] = " + student.Id+ " ORDER BY [course].Number";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dgv_myPlanCourse.DataSource = null;
                this.dgv_myPlanCourse.DataSource = dataTable;
            }
        }

        /// <summary>
        /// 点击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_allCourse.Columns[e.ColumnIndex].Name == "colBtn_preSelect")
            {//判断列名，点击的列是预选按钮的列

                //获取被选中行的数据
                int courseId = (int)dgv_allCourse.Rows[e.RowIndex].Cells[0].Value;
                string programName = dgv_allCourse.Rows[e.RowIndex].Cells[6].Value.ToString();

                if (programName.Equals(educationProgram.Name) == false)
                {//只允许选择与自己班级所在的培养方案相同的课程
                    MessageBox.Show("选课失败! 该课程的培养方案与您所在班级的培养方案不相同!");
                    return;
                }

                //查：表[PlanStudyCourseDao]
                PlanStudyCourseBean planStudyCourse = new PlanStudyCourseBean(courseId, 3, student.Id);
                PlanStudyCourseDao DAO = new PlanStudyCourseDao();
                if (DAO.FindByStuId_CourId_SemsId(planStudyCourse) != null)
                {
                    MessageBox.Show("您已预先过此门课，请不要重复选课!");
                    return;
                }
                //增：表[PlanStudyCourseDao]
                if (DAO.Add(planStudyCourse))
                {
                    ShowMyPlanCourse();
                    MessageBox.Show("选课成功!");
                }
            }
            if (dgv_allCourse.Columns[e.ColumnIndex].Name == "colBtn_formalSelect")
            {//判断列名，点击的列是正选按钮的列

                //获取被选中行的数据
                int courseClassId = (int)dgv_allCourse.Rows[e.RowIndex].Cells[0].Value;

                //查：表[class_student]
                ClassStudentBean classStudent = new ClassStudentBean(courseClassId, student.Id);
                ClassStudentDao DAO = new ClassStudentDao();
                if (DAO.FindByCourseClassId_StuId(classStudent) != null)
                {
                    MessageBox.Show("您已正选过此门课程，请不要重复选课!");
                    return;
                }
                //增：表[class_student]
                if (DAO.Add(classStudent))
                {
                    ShowMyFormalCourse();
                    MessageBox.Show("正式选课成功!");
                }
            }
        }
        /// <summary>
        /// 显示我已正选的课程
        /// </summary>
        void ShowMyFormalCourse()
        {
            String sqlStr = "SELECT [student].[scode] AS '学号',[student].[Name] AS '姓名' ,[course].[Cname] AS '课程名',[course].[Number] AS '课程编号'  ,[course_class].[Id] AS '开班ID',[teacher].[Name] AS '任课老师' FROM [class_student],[student],[course],[course_class],[teacher] WHERE[class_student].[Student_id] =[student].[id] AND[class_student].[course_class_id] =[course_class].[id] AND[course_class].[course_id] =[course].[id] AND[course_class].Teacher_id =[teacher].Id AND[student].scode = " + student.SCode;
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dgv_myPlanCourse.DataSource = null;
                this.dgv_myPlanCourse.DataSource = dataTable;
            }
        }

        /// <summary>
        /// 显示所有可正选的课程
        /// </summary>
        void ShowAllFormalCourse()
        {
            string sqlStr = "  SELECT [course_class].[id] AS'开班ID',[course].[Number] AS'课程编号',[course].[Cname] AS '课程名称',[teacher].[Name] AS '开班教师',[course].[Score] AS '学分',[course].Tchour AS '理论总学时' FROM [teacher],[course_class],[course] WHERE[teacher].[Id] =[course_class].[Teacher_id] AND[course].[Id] =[course_class].[course_id]";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView1的数据源
                this.dgv_allCourse.DataSource = null;
                this.dgv_allCourse.DataSource = dataTable;
            }

            //创建新的按钮列
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "colBtn_formalSelect";                     //列名
            col_Btn.HeaderText = "操作";                              //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "正式选择此课程";     //按钮上显示的文字
            this.dgv_allCourse.Columns.Add(col_Btn);                  //添加列
        }
        /// <summary>
        /// 点击DataGridView中的正选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_formalSelect_Click(object sender, EventArgs e)
        {
            //清除之前的按钮列
            this.dgv_allCourse.DataSource = null;
            this.dgv_allCourse.Columns.Clear();
            label2.Text = "已正式开班的课程：";
            label3.Text = "我已正选的课程：";
            ShowAllFormalCourse();
            ShowMyFormalCourse();
        }
        /// <summary>
        /// 点击DataGridView中的预选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_preSelect_Click(object sender, EventArgs e)
        {
            //清除之前的按钮列
            this.dgv_allCourse.DataSource = null;
            this.dgv_allCourse.Columns.Clear();
            label2.Text = "可预选的课程(2019年第3学期)：";
            label3.Text = "我已预选的课程：";

            ShowAllPlanCourse();
            ShowMyPlanCourse();
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            preForm.Show();
        }


    }
}
