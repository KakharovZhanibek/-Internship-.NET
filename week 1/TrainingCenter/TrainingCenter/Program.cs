using System;
using System.Collections.Generic;
using System.Linq;
using TrainingCenter.Classes;
using TrainingCenter.Interfaces;

namespace TrainingCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Course javaCourse = new Course("Java");

            Teacher teacher1 = new Teacher("Fufel", 29,
                new List<ICourse>()
                {
                    javaCourse
                });

            javaCourse.AssignTeacherToCourse(teacher1);
            javaCourse.CourseStudents = new List<IStudent>();
            javaCourse.StudentsCourseFinalRate = new Dictionary<IStudent, int?>();
            Student student1 = new Student("Sam", 19, new List<ICourse>());

            student1.SignUpForCourse(javaCourse);


            Console.WriteLine(javaCourse.CourseStudents.FirstOrDefault().Name + "   " + javaCourse.CourseTeacher.Name);
            Lesson lesson1 = new Lesson("Introduction", new Dictionary<IStudent, int?>());
            Lesson lesson2 = new Lesson("Data Types", new Dictionary<IStudent, int?>());

            teacher1.AddLessonToCourse(lesson1, javaCourse);
            teacher1.AddLessonToCourse(lesson2, javaCourse);

            Console.WriteLine(teacher1.Courses.Find(x => x.CourseName == javaCourse.CourseName).Lessons.FirstOrDefault().LessonTitle);

            teacher1.Courses.Find(x => x == javaCourse).Lessons.Find(x => x == lesson1).StudentsLessonsResults[student1] = 92;
            teacher1.Courses.Find(x => x == javaCourse).Lessons.Find(x => x == lesson2).StudentsLessonsResults[student1] = 95;

            foreach (var item in student1.ShowScoresOfCourseLessons(javaCourse))
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }

        }
    }
}
