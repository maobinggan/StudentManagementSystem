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
    class EducationProgramDao : BaseDao<EducationProgramBean>
    {
        public override bool Add(EducationProgramBean bean)
        {
            throw new NotImplementedException();
            return false;
        }
        /// <summary>
        /// 查：根据major_id
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public EducationProgramBean FindByMajorId(EducationProgramBean bean)
        {
            EducationProgramBean educationProgram = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [education_program] WHERE major_id=@major_id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@major_id", bean.Major_id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                educationProgram = ConvertToModel(dt);
                return educationProgram;
            }
            catch (Exception ex)
            {
                Console.WriteLine("【Exception】" + ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return educationProgram;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }
        public override EducationProgramBean FindById(EducationProgramBean bean)
        {
            EducationProgramBean educationProgram = null;
            try
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                String sqlStr = "SELECT * FROM [education_program] WHERE id=@id ";
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddWithValue("@id", bean.Id);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                //cmd.ExecuteNonQuery();

                //dataTable转模型
                educationProgram = ConvertToModel(dt);
                return educationProgram;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                return educationProgram;
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
