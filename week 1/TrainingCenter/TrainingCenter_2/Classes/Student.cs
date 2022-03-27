using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<ICourse> Courses { get; set; }        
        public Student(string Name, int Age, List<ICourse> courses)
        {
            this.Name = Name;
            this.Age = Age;
            this.Courses = courses;
        }
        public void SignUpForCourse(ICourse course)
        {
            if (course == null)
                throw new NullReferenceException();

            Courses.Add(course);
        }

        public void ShowScoresOfCourseLessons(ICourse course)
        {
           Courses.FirstOrDefault(x => x.CourseName == course.CourseName).Lessons.Select(x => x.StudentsLessonsResults.Where(x => x.Key == this));
        }
    }
}
