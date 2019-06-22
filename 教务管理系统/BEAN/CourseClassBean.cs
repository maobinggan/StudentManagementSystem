using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    /// <summary>
    /// 开班信息
    /// </summary>
    public class CourseClassBean
    {
        public int Id { get; set; }
        public int Semester_Id { get; set; }
        public int Course_Id { get; set; }
        public int Max_Class_Size { get; set; }
        public int Teacher_Id { get; set; }

        public CourseClassBean() { }

        public CourseClassBean(int id)
        {
            Id = id;
        }

        public CourseClassBean(int semester_Id, int course_Id, int max_Class_Size, int teacher_Id)
        {
            Semester_Id = semester_Id;
            Course_Id = course_Id;
            Max_Class_Size = max_Class_Size;
            Teacher_Id = teacher_Id;
        }
    }


}
