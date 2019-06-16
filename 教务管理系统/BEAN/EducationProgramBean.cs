using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务管理系统.BEAN
{
    public class EducationProgramBean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }
        public string Specification { get; set; }
        public int Duration { get; set; }
        public string Degree { get; set; }
        public int Min_credit { get; set; }
        public int Publish_year { get; set; }
        public int Major_id { get; set; }

        public EducationProgramBean()
        {
        }

        public EducationProgramBean(string name, string objective, string specification, int duration, string degree, int min_credit, int publish_year, int major_id)
        {
            Name = name;
            Objective = objective;
            Specification = specification;
            Duration = duration;
            Degree = degree;
            Min_credit = min_credit;
            Publish_year = publish_year;
            Major_id = major_id;
        }

        public EducationProgramBean(int id)
        {
            Id = id;
        }

    }
}
