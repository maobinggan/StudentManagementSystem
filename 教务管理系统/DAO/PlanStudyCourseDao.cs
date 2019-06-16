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
    class PlanStudyCourseDao : BaseDao<PlanStudyCourseBean> //泛型的具体类型为"PlanStudyCourse"
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Add(PlanStudyCourseBean bean)
        {
            try //正确的时候执行的内容
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "INSERT INTO [plan_study_course](course_id,semester_id,student_id) VALUES(@course_id,@semester_id,@student_id)";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_id", bean.Course_Id);
                cmd.Parameters.AddWithValue("@semester_id", bean.Semester_Id);
                cmd.Parameters.AddWithValue("@student_id", bean.Student_Id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }

        }

        public override PlanStudyCourseBean FindById(PlanStudyCourseBean bean)
        {
            PlanStudyCourseBean planStudyCourse = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [plan_study_course] WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                planStudyCourse = ConvertToModel(dt);
                return planStudyCourse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return planStudyCourse;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 查：根据StuId CourId SemsId
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public PlanStudyCourseBean FindByStuId_CourId_SemsId(PlanStudyCourseBean bean)
        {
            PlanStudyCourseBean planStudyCourse = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [plan_study_course] WHERE course_id=@course_id AND semester_id=@semester_id AND student_id=@student_id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_id", bean.Course_Id);
                cmd.Parameters.AddWithValue("@semester_id", bean.Semester_Id);
                cmd.Parameters.AddWithValue("@student_id", bean.Student_Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                planStudyCourse = ConvertToModel(dt);
                return planStudyCourse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return planStudyCourse;
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
