using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 教务管理系统.DAO;

namespace 教务管理系统.窗体
{
    public partial class ShowEducationProgramForm : Form
    {
        public ShowEducationProgramForm()
        {
            InitializeComponent();

            ShowInfo();
        }

        public void ShowInfo()
        {
            string sqlStr = "SELECT [student].scode AS '学号', [student].Name AS '姓名',[student].Gender AS '性别',[class].Name AS '班级名',[major].Name AS '专业',[education_program].Name AS '培养方案'FROM[student],[class],[major],[education_program] WHERE[student].Class_id=[class].Id AND[class].Major_id=[major].Id AND[education_program].Major_id=[major].Id";
            DataTable dataTable = BaseDao<object>.FindDataTable(sqlStr);
            if (dataTable != null)
            {
                //将数据集合的首张表绑定到dataGridView2的数据源
                this.dataGridView1.DataSource = dataTable;
            }
        }
    }
}
