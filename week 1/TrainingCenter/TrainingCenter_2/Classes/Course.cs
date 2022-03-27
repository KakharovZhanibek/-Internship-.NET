using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    public class Course
    {

        public string CourseName { get; set; }
        public ITeacher CourseTeacher { get; set; }
        List<IStudent> CourseStudents { get; set; }
#nullable enable
        public Dictionary<IStudent, int?> StudentsCourseFinalRate { get; set; } = null;
        //public Dictionary<string, int?> LessonAndRates { get; set; }

      //  public List<Dictionary<string, int?>> LessonAndRates { get; set; }
        //public int LessonCount { get; set; }
      /*  public Course(string courseName, int lessonCount)
        {
            CourseName = courseName;
            LessonCount = lessonCount;
        }*/

        public Course(string courseName, /*List<Dictionary<string, int?>> lessonAndRates,*/ITeacher teacher)
        {
            CourseName = courseName;
            CourseTeacher = teacher;
        }
    }
}
