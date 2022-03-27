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
        public List<ICourse> Courses { get; set; }

        public Teacher(string Name, int Age, List<ICourse> courses)
        {
            this.Name = Name;
            this.Age = Age;
            this.Courses = courses;
        }
        public void AddLessonToCourse(Lesson lesson,ICourse course)
        {
            if (lesson == null || course == null)
                throw new NullReferenceException();

            Courses.Find(x => x.CourseName == course.CourseName).Lessons.Add(lesson);

            foreach (var student in this.Courses.FirstOrDefault(x=>x==course).CourseStudents)
            {
                lesson.StudentsLessonsResults.Add(student, null);
            }
        }
        public void GiveMarkToLesson(ICourse course, IStudent student, Lesson lesson,int score)
        {
            Courses.Find(x => x.CourseName == course.CourseName)
                .Lessons.Find(x=>x.LessonTitle==lesson.LessonTitle)
                .StudentsLessonsResults.Add(student,score);
        }

        public void AddCourseToTeacher(ICourse course)
        {
            if (course == null)
                throw new NullReferenceException();

            this.Courses.Add(course);
        }
    }
}
