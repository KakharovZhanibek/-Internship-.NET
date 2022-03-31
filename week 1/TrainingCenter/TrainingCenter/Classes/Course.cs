using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    public class Course : ICourse
    {
        public string CourseName { get; set; }
        public ITeacher CourseTeacher { get; set; }
        public List<IStudent> CourseStudents { get; set; } = new List<IStudent>();
        public Dictionary<IStudent, int?> StudentsCourseFinalRate { get; set; } = new Dictionary<IStudent, int?>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public Course(string courseName, ITeacher teacher):this(courseName)
        {
            CourseTeacher = teacher;
        }
        public Course(string courseName)
        {
            CourseName = courseName;
        }
        
        public Dictionary<string, int> GetStudentsLessonsScores(IStudent student)
        {
            Dictionary<string, int> lessonsRates = new Dictionary<string, int>();

            foreach (Lesson lesson in this.Lessons)
            {
                lessonsRates.Add(lesson.LessonTitle, lesson.StudentsLessonsResults[student]);
            }
            return lessonsRates;
        }
    }
}
