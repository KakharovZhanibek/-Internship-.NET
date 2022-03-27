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

        //public string Name { get; set; }
        //public int Age { get; set; }
        //public Dictionary<ICourse, int?> Courses { get; set; }

        //public Student(string Name, int Age, Dictionary<ICourse, int?> courses)
        //{
        //    this.Name = Name;
        //    this.Age = Age;
        //    this.Courses = courses;
        //}
        //public void SignUpForCourse(ICourse course)
        //{
        //    if (course == null)
        //        throw new NullReferenceException();

        //    Courses.Add(course, null);
        //}
        //public void ShowScoresOfCourseLessons(ICourse course)
        //{
        //   Courses.FirstOrDefault(x => x.Key == course).Key.Lessons.Select(x => x.StudentsLessonsResults.Where(x => x.Key == this));
        //}

        public string Name { get; set; }
        public int Age { get; set; }
        public List<ICourse> Courses { get; set; }
        public Student(string Name, int Age, List<ICourse> courses)
        {
            this.Name = Name;
            this.Age = Age;
            this.Courses = courses;
        }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void SignUpForCourse(ICourse course)
        {
            if (course == null)
                throw new NullReferenceException();

            Courses.Add(course);

            course.AddStudentToCourse(this);
        }

        public Dictionary<string,int?> ShowScoresOfCourseLessons(ICourse course)
        {
            return course.GetStudentsLessonsScores(this);
        }
    }
}
