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
    class ClassStudentDao : BaseDao<ClassStudentBean>
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public override bool Add(ClassStudentBean bean)
        {
            try //正确的时候执行的内容
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "INSERT INTO [class_student](course_class_id,student_id,gpa_score,paper_score,practice_score,score) VALUES(@course_class_id,@student_id,@gpa_score,@paper_score,@practice_score,@score)";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_class_id", bean.Course_Class_Id);
                cmd.Parameters.AddWithValue("@student_id", bean.Student_Id);
                cmd.Parameters.AddWithValue("@gpa_score", bean.Gpa_Score);
                cmd.Parameters.AddWithValue("@paper_score", bean.Paper_Score);
                cmd.Parameters.AddWithValue("@practice_score", bean.Practice_Score);
                cmd.Parameters.AddWithValue("@score", bean.Score);

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

        /// <summary>
        /// 查：根据StuId CourseClassId
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public ClassStudentBean FindByCourseClassId_StuId(ClassStudentBean bean)
        {
            ClassStudentBean classStudent = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [class_student] WHERE course_class_id=@course_class_id AND student_id=@student_id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_class_id", bean.Course_Class_Id);
                cmd.Parameters.AddWithValue("@student_id", bean.Student_Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                classStudent = ConvertToModel(dt);
                return classStudent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return classStudent;
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
        /// <param name="bean"></param>
        /// <returns></returns>
        public override ClassStudentBean FindById(ClassStudentBean bean)
        {
            ClassStudentBean classStudent = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [class_student] WHERE id=@id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                classStudent = ConvertToModel(dt);
                return classStudent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return classStudent;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }

        }


        /// <summary>
        /// 查多条记录：根据Course_Class
        /// </summary>
        /// <param name="bean"></param>
        /// <returns>List</returns>
        public List<ClassStudentBean> FindListById(ClassStudentBean bean)
        {
            List<ClassStudentBean> classStudentList = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [class_student] WHERE Course_Class_Id=@Course_Class_Id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@Course_Class_Id", bean.Course_Class_Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                classStudentList = ConvertToList(dt);
                return classStudentList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return classStudentList;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }

        }
        /// <summary>
        /// 改
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public bool UpdateById(ClassStudentBean bean)
        {
            try //正确的时候执行的内容
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "UPDATE [class_student] SET course_class_id=@course_class_id,Student_id=@Student_id,Gpa_score=@Gpa_score,Paper_score=@Paper_score,Practice_score=@Practice_score,Score=@Score WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@course_class_id", bean.Course_Class_Id);
                cmd.Parameters.AddWithValue("@Student_id", bean.Student_Id);
                cmd.Parameters.AddWithValue("@Gpa_score", bean.Gpa_Score);
                cmd.Parameters.AddWithValue("@Paper_score", bean.Paper_Score);
                cmd.Parameters.AddWithValue("@Practice_score", bean.Practice_Score);
                cmd.Parameters.AddWithValue("@Score", bean.Score);
                cmd.Parameters.AddWithValue("@Id", bean.Id);
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
