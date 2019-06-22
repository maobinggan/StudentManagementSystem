using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{

    public class StudentBean
    {
        public int Id { get; set; }
        public string SCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public int Class_Id { get; set; }

        public StudentBean(int id)
        {
            Id = id;
        }

        public StudentBean(string sCode, string name, string gender, string photo, int class_Id)
        {
            SCode = sCode;
            Name = name;
            Gender = gender;
            Photo = photo;
            Class_Id = class_Id;
        }

        public StudentBean()
        {
        }
    }
}
