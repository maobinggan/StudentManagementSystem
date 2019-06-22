using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    class CourseBean
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string CName { get; set; }
        public string EName { get; set; }
        public int Score { get; set; }
        public int CHour { get; set; }
        public int LHour { get; set; }
        public int TCHour { get; set; }
        public int TLHour { get; set; }

        public CourseBean()
        {
        }

        public CourseBean(int id)
        {
            Id = id;
        }

        public CourseBean(string number, string cName, string eName, int score, int cHour, int lHour, int tCHour, int tLHour)
        {
            Number = number;
            CName = cName;
            EName = eName;
            Score = score;
            CHour = cHour;
            LHour = lHour;
            TCHour = tCHour;
            TLHour = tLHour;
        }
    }
}
