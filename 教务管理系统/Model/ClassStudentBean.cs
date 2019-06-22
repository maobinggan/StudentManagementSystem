using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    /// <summary>
    /// 开班的班级学生信息
    /// </summary>
    class ClassStudentBean
    {
        public int Id { get; set; }
        public int Course_Class_Id { get; set; }
        public int Student_Id { get; set; }
        public int Gpa_Score { get; set; }
        public int Paper_Score { get; set; }
        public int Practice_Score { get; set; }
        public int Score { get; set; }

        public ClassStudentBean()
        {
        }

        public ClassStudentBean(int course_Class_Id, int student_Id, int gpa_Score, int paper_Score, int practice_Score, int score) : this(course_Class_Id, student_Id)
        {
            Gpa_Score = gpa_Score;
            Paper_Score = paper_Score;
            Practice_Score = practice_Score;
            Score = score;
        }

        public ClassStudentBean(int id)
        {
            Id = id;
        }

        public ClassStudentBean(int courseClassId, int studentId)
        {
            Course_Class_Id = courseClassId;
            Student_Id = studentId;
        }
    }
}
