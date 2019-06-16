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
        public int courseId { get; set; }
        public int semesterId { get; set; }
        public int studentId { get; set; }

        public PlanStudyCourseBean()
        {
        }

        public PlanStudyCourseBean(int courseId, int semesterId, int studentId)
        {
            this.courseId = courseId;
            this.semesterId = semesterId;
            this.studentId = studentId;
        }

    }
}
