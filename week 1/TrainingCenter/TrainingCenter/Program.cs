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
            TrainingCenterService trainingCenterService = new TrainingCenterService();

            Course javaCourse = new Course("Java");

            Teacher teacher1 = new Teacher("Fufel", 29);

            Student student1 = new Student("Sam", 19);
            Student student2 = new Student("Jack", 20);

            trainingCenterService.AddCourseToCenter(javaCourse);

            trainingCenterService.AddTeacherToCenter(teacher1);

            trainingCenterService.AddStudentToCenter(student1);
            trainingCenterService.AddStudentToCenter(student2);

            trainingCenterService.AssignTeacherToCourse(teacher1, javaCourse);

            trainingCenterService.AddStudentToCourse(student1, javaCourse);
            trainingCenterService.AddStudentToCourse(student2, javaCourse);
            //Console.WriteLine(javaCourse.CourseStudents.FirstOrDefault().Name + "   " + javaCourse.CourseTeacher.Name);
            Lesson lesson1 = new Lesson("Introduction");
            Lesson lesson2 = new Lesson("Data Types");

            trainingCenterService.AddLessonToCourse(javaCourse, lesson1);
            trainingCenterService.AddLessonToCourse(javaCourse, lesson2);

            teacher1.GiveMarkToLesson(javaCourse, student1, lesson1, 100);
            teacher1.GiveMarkToLesson(javaCourse, student1, lesson2, 95);

            teacher1.GiveMarkToLesson(javaCourse, student2, lesson1, 95);
            teacher1.GiveMarkToLesson(javaCourse, student2, lesson2, 85);

            foreach (IStudent student in javaCourse.CourseStudents)
            {
                Console.WriteLine(student.Name);
                foreach (var lessonMark in student.ShowScoresOfCourseLessons(javaCourse))
                {
                    Console.WriteLine(lessonMark.Key + "   " + lessonMark.Value);
                }

            }
            trainingCenterService.SummorizeCourse(javaCourse);

            Console.WriteLine(javaCourse.CourseName);
            foreach (var studentMark in trainingCenterService.TrainingCenterCourses.Find(x => x.Equals(javaCourse)).StudentsCourseFinalRate)
            {

                Console.WriteLine(studentMark.Key.Name + "   " + studentMark.Value);
            }
        }
    }
}
