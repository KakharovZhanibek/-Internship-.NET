using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Classes;
using TrainingCenter.Interfaces;

namespace TrainingCenter_2
{
    public class SeedExtension
    {
        public void CreateDefaultData()
        {
            //var lesson_1 = new Lesson("lesson_1");
            var lessonAndRates = new Dictionary<string, int?>();
            lessonAndRates.Add("lesson_1", null);
            lessonAndRates.Add("lesson_2", null);
            lessonAndRates.Add("lesson_3", null);
            lessonAndRates.Add("lesson_4", null);
            lessonAndRates.Add("lesson_5", null);

            var lessonAndRates_2 = new Dictionary<string, int?>();
            lessonAndRates_2.Add("lesson_1", null);
            lessonAndRates_2.Add("lesson_2", null);
            lessonAndRates_2.Add("lesson_3", null);
            lessonAndRates_2.Add("lesson_4", null);
            lessonAndRates_2.Add("lesson_5", null);
            Course javaCourse = new Course("Java", 20);
            //javaCourse.CourseStudents = 
            Course cSharpCourse = new Course("C#", 30);
            Course rubyCourse = new Course("Ruby", 10);
            Course cloudCourse = new Course("Clouds", 5);

            Student student1 = new Student("Sam", 19,
                new List<Course>()
                {
                    {javaCourse},
                    {rubyCourse}
                }
            );
            Student student2 = new Student("George", 20,
                new List<Course>()
                {
                    {cSharpCourse},
                    {rubyCourse}
                }
            );

            ReportCard reportCard_1 = new ReportCard("Sam", student1.Courses[0].CourseName, lessonAndRates);
            ReportCard reportCard_2 = new ReportCard("Sam", student1.Courses[1].CourseName, lessonAndRates);


            ReportCard reportCard_3 = new ReportCard("George", student1.Courses[0].CourseName, lessonAndRates);
            ReportCard reportCard_4 = new ReportCard("George", student1.Courses[1].CourseName, lessonAndRates_2);

            List<ReportCard> reportCards = new List<ReportCard>() { reportCard_1, reportCard_2, reportCard_3, reportCard_4 };


            reportCard_1.StudentsLessonsRates["lesson_1"] = 5;

            var reportCardByStudentName = reportCards.FirstOrDefault(x => x.StudentName == "Sam");

            Console.WriteLine(reportCardByStudentName.StudentName);

            foreach(var item in reportCardByStudentName.StudentsLessonsRates)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }
            Console.WriteLine("\n \n");

           
            Console.WriteLine(reportCard_4.StudentName);
            foreach (var item in reportCard_4.StudentsLessonsRates)
            {
                Console.WriteLine(item.Key + "   " + item.Value);
            }

        }


    }
}
