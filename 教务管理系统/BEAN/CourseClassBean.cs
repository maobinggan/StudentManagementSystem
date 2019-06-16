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
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int MaxClassSize { get; set; }
        public int TeacherId { get; set; }

        public CourseClassBean() { }

        public CourseClassBean(int id)
        {
            Id = id;
        }

        public CourseClassBean(int semesterId, int courseId, int maxClassSize, int teacherId)
        {
            SemesterId = semesterId;
            CourseId = courseId;
            MaxClassSize = maxClassSize;
            TeacherId = teacherId;
        }
    }


}
