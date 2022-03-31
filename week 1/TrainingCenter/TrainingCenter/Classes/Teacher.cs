using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    class Teacher : ITeacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ICourse> Courses { get; set; } = new List<ICourse>();

        public Teacher(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public Teacher(string Name, int Age, List<ICourse> courses) : this(Name, Age)
        {
            this.Courses = courses;
        }

        public void GiveMarkToLesson(ICourse course, IStudent student, Lesson lesson, int score)
        {
            Courses.Find(x => x.CourseName == course.CourseName)
                .Lessons.Find(x => x.Equals(lesson))
                .StudentsLessonsResults.Add(student, score);
        }
    }
}
