using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{

    public class TeacherBean
    {
        public int Id { get; set; }
        public string TCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Degree { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Photo { get; set; }

        public TeacherBean(int id)
        {
            Id = id;
        }

        public TeacherBean(string code, string name, string gender, string degree, string title, string introduction, string photo)
        {
            TCode = code;
            Name = name;
            Gender = gender;
            Degree = degree;
            Title = title;
            Introduction = introduction;
            Photo = photo;
        }

        public TeacherBean()
        {
        }
    }
}
