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
    class ClassDao : BaseDao<ClassBean>
    {
        public override bool Add(ClassBean bean)
        {
            throw new NotImplementedException();
            return false;
        }

        public override ClassBean FindById(ClassBean bean)
        {
            ClassBean classBean = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [class] WHERE id=@id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                classBean = ConvertToModel(dt);
                return classBean;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return classBean;
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
