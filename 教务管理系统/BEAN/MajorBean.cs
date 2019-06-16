using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    /// <summary>
    /// 专业(方向)信息
    /// </summary>
    public class MajorBean
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MajorBean()
        {
        }

        public MajorBean(int id)
        {
            Id = id;
        }

        public MajorBean(string name)
        {
            Name = name;
        }
    }
}
