using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    public class Lesson
    {
        public string LessonTitle { get; set; }
        //IPerson teacher;
        public Dictionary<IStudent, int?> StudentsLessonsResults;

        public Lesson(string lessonTitle, Dictionary<IStudent, int?> studentsLessonsResults)
        {
            LessonTitle = lessonTitle;
            StudentsLessonsResults = studentsLessonsResults;
        }
    }
}
