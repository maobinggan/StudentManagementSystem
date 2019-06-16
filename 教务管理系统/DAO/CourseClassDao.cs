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
    class CourseClassDao : BaseDao<CourseClassBean>
    {
        /// <summary>
        /// 查：根据CourId TeacherId
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public CourseClassBean FindByCourId_TeacherId(CourseClassBean bean)
        {
            CourseClassBean courseClass = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [course_class] WHERE course_id=@course_id AND teacher_id=@teacher_id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_id", bean.Course_Id);
                cmd.Parameters.AddWithValue("@teacher_id", bean.Teacher_Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                courseClass = ConvertToModel(dt);
                return courseClass;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return courseClass;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 查：根据id
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override CourseClassBean FindById(CourseClassBean bean)
        {
            CourseClassBean courseClass = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [course_class] WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                courseClass = ConvertToModel(dt);
                return courseClass;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return courseClass;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Add(CourseClassBean bean)
        {
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "INSERT INTO [course_class](course_id,semester_id,teacher_id,max_class_size) VALUES(@course_id,@semester_id,@teacher_id,@max_class_size)";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_id", bean.Course_Id);
                cmd.Parameters.AddWithValue("@semester_id", bean.Semester_Id);
                cmd.Parameters.AddWithValue("@teacher_id", bean.Teacher_Id);
                cmd.Parameters.AddWithValue("@max_class_size", bean.Max_Class_Size);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return false;
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
