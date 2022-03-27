using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> courses { get; set; }

        public Teacher(string Name, int Age, List<Course> courses)
        {
            this.Name = Name;
            this.Age = Age;
            this.courses = courses;
        }
    /*    public void AddLessonToCourse(Lesson lesson,ICourse course)
        {
            courses.Find(x => x.CourseName == course.CourseName).Lessons.Add(lesson);
        }
        public void GiveMarkToLesson(Course course, Student student, Lesson lesson,int score)
        {
            courses.Find(x => x.CourseName == course.CourseName)
                .Lessons.Find(x=>x.LessonTitle==lesson.LessonTitle)
                .StudentsLessonsResults.Add(student,score);
        }*/
    }
}
