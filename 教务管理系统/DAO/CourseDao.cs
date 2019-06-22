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
    class CourseDao : BaseDao<CourseBean>
    {
        /// <summary>
        /// 查：根据课程编号
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public CourseBean FindByNumber(CourseBean bean)
        {
            CourseBean course = null;
            try {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [course] WHERE number=@number";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@number", bean.Number);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                course = ConvertToModel(dt);
                return course;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return course;
            }
            finally {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }


        public override bool Add(CourseBean bean)
        {
            return false;
        }

        public override CourseBean FindById(CourseBean bean)
        {
            return null;
        }
    }
}
