using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Classes;

namespace TrainingCenter.Interfaces
{
    public interface ITeacher:IPerson
    {
        List<ICourse> Courses { get; set; }

        void AddCourseToTeacher(ICourse course);
        void AddLessonToCourse(Lesson lesson,ICourse course);
    }
}
