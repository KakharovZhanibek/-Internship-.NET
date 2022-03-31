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
        void GiveMarkToLesson(ICourse course, IStudent student, Lesson lesson, int score);
    }
}
