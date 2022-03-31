using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Interfaces
{
    public interface IStudent : IPerson
    {
        List<ICourse> Courses { get; set; }
        Dictionary<string, int> ShowScoresOfCourseLessons(ICourse course);
    }
}
