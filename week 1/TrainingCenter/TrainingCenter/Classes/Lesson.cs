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
        public Dictionary<IStudent, int> StudentsLessonsResults;

        public Lesson(string lessonTitle)
        {
            LessonTitle = lessonTitle;
            StudentsLessonsResults = new Dictionary<IStudent, int>();
        }
    }
}
