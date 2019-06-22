using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 教务管理系统.BEAN;

namespace 教务管理系统.DAO
{
    class StudentDao : BaseDao<StudentBean>
    {
        /// <summary>
        /// 查：根据学号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public StudentBean FindBySCode(string sCode)
        {
            StudentBean studentBean = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                string sqlStr = "SELECT * FROM [student] WHERE sCode=@sCode";//占位符
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@sCode", sCode);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //dataTable转模型
                studentBean = ConvertToModel(dt);
                return studentBean;
            }
            catch (Exception ex)
            {
                Console.WriteLine("【Execption】" + ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return studentBean;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 查：根据Id
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        public override StudentBean FindById(StudentBean bean)
        {
            StudentBean studentBean = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                string sqlStr = "SELECT * FROM [student] WHERE id=@id";//占位符
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //dataTable转模型
                studentBean = ConvertToModel(dt);
                return studentBean;
            }
            catch (Exception ex)
            {
                Console.WriteLine("【Execption】" + ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return studentBean;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
        public override bool Add(StudentBean bean)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}
