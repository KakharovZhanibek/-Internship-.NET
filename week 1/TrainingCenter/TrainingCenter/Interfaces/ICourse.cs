using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Classes;

namespace TrainingCenter.Interfaces
{
    public interface ICourse
    {
        string CourseName { get; set; }
        ITeacher CourseTeacher { get; set; }
        List<IStudent> CourseStudents { get; set; }
        List<Lesson> Lessons { get; set; }

        void AddStudentToCourse(IStudent student);
        void AssignTeacherToCourse(ITeacher teacher);
        Dictionary<string, int?> GetStudentsLessonsScores(IStudent student);
    }
}
