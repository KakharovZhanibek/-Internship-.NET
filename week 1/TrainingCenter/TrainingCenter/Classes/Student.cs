using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    class Student : IStudent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ICourse> Courses { get; set; } = new List<ICourse>();

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public Student(string Name, int Age, List<ICourse> Courses):this(Name,Age)
        {
            this.Courses = Courses;
        }
        public Dictionary<string,int> ShowScoresOfCourseLessons(ICourse course)
        {
            return course.GetStudentsLessonsScores(this);
        }
    }
}
