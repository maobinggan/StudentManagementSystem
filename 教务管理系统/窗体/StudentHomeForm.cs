using CCWin.SkinControl;
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
    public partial class StudentHomeForm : MainForm
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

            skinLabel1.Text = "[姓  名]:" + student.Name + "  [学号]:" + student.SCode;
            skinLabel2.Text = "[专业名]:" + major.Name + " [班级名]:" + classBean.Name;
            skinLabel3.Text = "[培养方案]:" + educationProgram.Name;

        }

        /// <summary>
        /// 显示所有预选课程
        /// </summary>
        private void ShowAllPlanCourse(DataGridView dgv)
        {
            //清除数据源，防止乱序
            dgv.DataSource = null;
            dgv.Columns.Clear();

            String sqlStr = "SELECT [course].id AS '课程ID',[course].Number AS '课程编号',[cname] AS '课程名称',[Score] AS'学分',[Tlhour] AS '周学时' ,[category_course].Name AS '课程类别' ,[education_program].Name AS '培养方案'FROM[course],[curriculum],[category_course],[education_program] WHERE [curriculum].course_id = [course].id AND [curriculum].Category_id=[category_course].id AND [curriculum].Program_id= [education_program].id ORDER BY [course].Number";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null) {
                //将数据集合的首张表绑定到dataGridView1的数据源
                dgv.DataSource = null;
                dgv.DataSource = dataTable;
            }
            //添加一列按钮，按钮的行数取决于DataGridView的行数
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "colBtn_preSelect";                          //列名
            col_Btn.HeaderText = "操作";                                //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "预选";                //按钮上显示的文字
            dgv.Columns.Add(col_Btn);                                   //添加列
        }
        /// <summary>
        /// 显示我已选的预选课程
        /// </summary>
        private void ShowMyPlanCourse(DataGridView dgv)
        {
            //清除数据源，防止乱序
            dgv.DataSource = null;
            dgv.Columns.Clear();

            String sqlStr = "SELECT [student].[scode]AS '学生学号', [student].[Name]AS '学生姓名',[course].[number]AS '课程编号',[course].[Cname]AS '课程名',[course].[score] AS '学分',[semester].[Name] AS '学期信息',[category_course].Name AS '课程类别' ,[education_program].Name AS '培养方案' FROM[course],[student],[semester],[plan_study_course],[curriculum],[category_course],[education_program] WHERE[student].[id]=[plan_study_course].[Student_id] AND[course].[id]=[plan_study_course].[course_id] AND[semester].[id]=[plan_study_course].[Semester_id] AND[curriculum].course_id = [course].id AND[curriculum].Category_id=[category_course].id AND[curriculum].Program_id= [education_program].id AND[plan_study_course].[Student_id] = " + student.Id + " ORDER BY [course].Number";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null) {
                //将数据集合的首张表绑定到dataGridView1的数据源
                dgv.DataSource = null;
                dgv.DataSource = dataTable;
            }
            //添加一列按钮，按钮的行数取决于DataGridView的行数
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "colBtn_preDelete";                          //列名
            col_Btn.HeaderText = "操作";                                //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "撤销预选";                //按钮上显示的文字
            dgv.Columns.Add(col_Btn);                                   //添加列
        }

        /// <summary>
        /// 监听组合框的值变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox1.Text.Equals("预选：所有可预选的课程")) {
                ShowAllPlanCourse(this.skinDataGridView1);
            }
            if (skinComboBox1.Text.Equals("正选：所有可正选的课程")) {
                ShowAllFormalCourse(this.skinDataGridView1);
            }
            if (skinComboBox1.Text.Equals("正选：我已正选的课程")) {
                ShowMyFormalCourse(this.skinDataGridView1);
            }
            if (skinComboBox1.Text.Equals("预选：我已预选的课程")) {
                ShowMyPlanCourse(this.skinDataGridView1);
            }
        }

        /// <summary>
        /// 点击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellContent_Click(object sender, DataGridViewCellEventArgs e)
        {
            //当点击'预选课'按钮时
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_preSelect") {
                //获取被选中行的数据
                int courseId = (int)skinDataGridView1.Rows[e.RowIndex].Cells[0].Value;              //首列的数据
                string programName = skinDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();  //第7列的数据

                if (programName.Equals(educationProgram.Name) == false) {//只允许选择与自己班级所在的培养方案相同的课程
                    this.Warning("选课失败! 该课程的培养方案与您所在班级的培养方案不相同!");
                    return;
                }

                //查：表[PlanStudyCourseDao]
                PlanStudyCourseBean planStudyCourse = new PlanStudyCourseBean(courseId, 3, student.Id);
                PlanStudyCourseDao DAO = new PlanStudyCourseDao();
                if (DAO.FindByStuId_CourId_SemsId(planStudyCourse) != null) {
                    this.Warning("选课失败！您已预先过此门课，请不要重复选课!");
                    return;
                }
                //增：表[PlanStudyCourseDao]
                if (DAO.Add(planStudyCourse)) {
                    this.Info("预选成功!");
                }
            }

            //当点击'正式选课'按钮时
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_formalSelect") {
                //获取被选中行的数据
                int courseClassId = (int)skinDataGridView1.Rows[e.RowIndex].Cells[0].Value;

                //查：表[class_student]
                ClassStudentBean classStudent = new ClassStudentBean(courseClassId, student.Id);
                ClassStudentDao DAO = new ClassStudentDao();
                if (DAO.FindByCourseClassId_StuId(classStudent) != null) {
                    this.Warning("选课失败！您已正选过此门课程，请不要重复选课!");
                    return;
                }
                //增：表[class_student]
                if (DAO.Add(classStudent)) {
                    this.Info("正式选课成功!");
                }
            }

            //当点击'撤销预选课'按钮时
            if (skinDataGridView1.Columns[e.ColumnIndex].Name == "colBtn_preDelete") {

                //获取被选中行的数据
                string number = skinDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();  //第3列的数据

                //获取目标课程的课程编号
                CourseDao courseDAO = new CourseDao();
                CourseBean course = courseDAO.FindByNumber(new CourseBean(number, null, null, 0, 0, 0, 0, 0));

                //获取目标预选课的预选ID
                PlanStudyCourseBean planStudyCourse = new PlanStudyCourseBean(course.Id, 3, student.Id);
                PlanStudyCourseDao planStudyCourseDao = new PlanStudyCourseDao();
                planStudyCourse = planStudyCourseDao.FindByStuId_CourId_SemsId(planStudyCourse);

                //删除目标预选课
                planStudyCourseDao.DeleteById(planStudyCourse);

                //刷新表格
                ShowMyPlanCourse(this.skinDataGridView1);
                this.Info("已删除!");
            }
        }
        /// <summary>
        /// 显示我已正选的课程
        /// </summary>
        void ShowMyFormalCourse(DataGridView dgv)
        {
            //清除数据源，防止乱序
            dgv.DataSource = null;
            dgv.Columns.Clear();

            String sqlStr = "SELECT [student].[scode] AS '学号',[student].[Name] AS '姓名' ,[course].[Cname] AS '课程名',[course].[Number] AS '课程编号'  ,[course_class].[Id] AS '开班ID',[teacher].[Name] AS '任课老师' FROM [class_student],[student],[course],[course_class],[teacher] WHERE[class_student].[Student_id] =[student].[id] AND[class_student].[course_class_id] =[course_class].[id] AND[course_class].[course_id] =[course].[id] AND[course_class].Teacher_id =[teacher].Id AND[student].scode = " + student.SCode;
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null) {
                //将数据集合的首张表绑定到dataGridView1的数据源
                dgv.DataSource = null;
                dgv.DataSource = dataTable;
            }
        }

        /// <summary>
        /// 显示所有可正选的课程
        /// </summary>
        void ShowAllFormalCourse(DataGridView dgv)
        {
            //清除数据源，防止乱序
            dgv.DataSource = null;
            dgv.Columns.Clear();

            string sqlStr = "  SELECT [course_class].[id] AS'开班ID',[course].[Number] AS'课程编号',[course].[Cname] AS '课程名称',[teacher].[Name] AS '开班教师',[course].[Score] AS '学分',[course].Tchour AS '理论总学时' FROM [teacher],[course_class],[course] WHERE[teacher].[Id] =[course_class].[Teacher_id] AND[course].[Id] =[course_class].[course_id]";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null) {
                //将数据集合的首张表绑定到dataGridView1的数据源
                dgv.DataSource = null;
                dgv.DataSource = dataTable;
            }

            //创建新的按钮列
            DataGridViewButtonColumn col_Btn = new DataGridViewButtonColumn();
            col_Btn.Name = "colBtn_formalSelect";                     //列名
            col_Btn.HeaderText = "操作";                              //该列表头所显示的文字
            col_Btn.DefaultCellStyle.NullValue = "正式选课";            //按钮上显示的文字
            this.skinDataGridView1.Columns.Add(col_Btn);               //添加列
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
