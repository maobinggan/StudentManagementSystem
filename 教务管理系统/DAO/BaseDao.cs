using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 教务管理系统.DAO
{

    /// <summary>
    /// 定义抽象类，以泛型为参数。即当实例化或继承此抽象类时，必须指明该泛型的具体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /*
    * <T> where T :new ()  表示A类接受某一种类型，泛型类型为T，需要运行时传入。
    * where表明了对类型变量T的约束关系。where T：new()指明了创建T的实例时应该具有构造函数。
    * 一般情况下，是无法创建一个泛型类型参数的实例。然而，new()约束改变了这种情况，要求类型参数必须提供一个无参数的构造函数。
    */
    abstract class BaseDao<T> where T : new()
    {
        protected static String connStr = "server=127.0.0.1;uid=sa;pwd=123456;database=StudentManagementSystem";
        protected static SqlConnection conn = null;
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="bean"></param>
        public abstract bool Add(T bean);

        /// <summary>
        /// 查：通过Id
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public abstract T FindById(T bean);

        /// <summary>
        /// 查 (DataSet)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static DataTable FindDataTable(String sqlStr)
        {
            DataTable dataTable = null;
            try //正确的时候执行的内容
            {
                //连接数据库
                conn = new SqlConnection(connStr); //数据库连接对象
                conn.Open();
                //SQL
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                dataTable = new DataTable();
                new SqlDataAdapter(cmd).Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                return dataTable;
            }
            finally
            {
                //关闭连接
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 将DataTable转换成T模型
        /// 注意，T模型的各属性必须有{get;set;}函数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T ConvertToModel(DataTable dt)
        {
            //实例化泛型对象
            T t = new T();
            if (dt != null)
            {
                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                //只反射第一行的结果
                DataRow dr = dt.Rows[0];
                // 获得泛型的所有公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//获取属性名
                    if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                    {
                        //如果该属性是否可写(有setter方法)，则把列的值赋值给该属性
                        if (pi.CanWrite)
                        {
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }

                    }
                }
            }
            return t;
        }
        /// <summary>
        /// 转为List
        /// 注意，T模型的各属性必须有{get;set;}函数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertToList(DataTable dt)
        {
            List<T> ts = new List<T>();
            if (dt != null)
            {
                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    //实例化泛型对象
                    T t = new T();
                    // 获得泛型的所有公共属性      
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;//获取属性名
                        if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                        {
                            //如果该属性是否可写(有setter方法)，则把列的值赋值给该属性
                            if (pi.CanWrite)
                            {
                                object value = dr[tempName];
                                if (value != DBNull.Value)
                                    pi.SetValue(t, value, null);
                            }

                        }
                    }
                    //遍历一次后，将泛型的Bean对象添加至集合
                    ts.Add(t);
                }
                return ts;
            }
            return ts;
        }
    }
}
