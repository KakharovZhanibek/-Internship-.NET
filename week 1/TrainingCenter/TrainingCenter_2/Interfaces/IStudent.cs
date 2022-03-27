using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Interfaces
{
    public interface IStudent
    {
        Dictionary<ICourse, int?> Courses { get; set; }
        void SignUpForCourse(ICourse course);
        void ShowScoresOfCourseLessons(ICourse course);
    }
}
