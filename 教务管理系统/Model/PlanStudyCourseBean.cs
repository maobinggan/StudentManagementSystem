using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    class PlanStudyCourseBean
    {
        public int Id { get; set; }
        public int Course_Id { get; set; }
        public int Semester_Id { get; set; }
        public int Student_Id { get; set; }

        public PlanStudyCourseBean()
        {
        }

        public PlanStudyCourseBean(int id)
        {
            Id = id;
        }

        public PlanStudyCourseBean(int course_Id, int semester_Id, int student_Id)
        {
            this.Course_Id = course_Id;
            this.Semester_Id = semester_Id;
            this.Student_Id = student_Id;
        }

    }
}
