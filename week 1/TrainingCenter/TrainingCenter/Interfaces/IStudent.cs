using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Interfaces
{
    public interface IStudent:IPerson
    {
        List<ICourse> Courses { get; set; }
        void SignUpForCourse(ICourse course);
        Dictionary<string, int?> ShowScoresOfCourseLessons(ICourse course);
    }
}
