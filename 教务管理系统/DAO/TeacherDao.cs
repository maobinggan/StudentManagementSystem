using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 教务管理系统.BEAN;

namespace 教务管理系统.DAO
{
    class TeacherDao : BaseDao<TeacherBean>
    {
        public TeacherBean FindByTCode(string tCode)
        {
            TeacherBean teacher = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                string sqlStr = "SELECT * FROM [teacher] WHERE tCode=@tCode";//占位符
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@tCode", tCode);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //dataTable转模型
                teacher = ConvertToModel(dt);
                return teacher;
            }
            catch (Exception ex)
            {
                Console.WriteLine("【Execption】" + ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return teacher;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        public override bool Add(TeacherBean bean)
        {
            //throw new NotImplementedException();
            return false;
        }

        public override TeacherBean FindById(TeacherBean bean)
        {
            TeacherBean teacher = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [teacher] WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                teacher = ConvertToModel(dt);
                return teacher;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return teacher;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

