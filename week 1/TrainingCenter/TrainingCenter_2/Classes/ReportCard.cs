using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    public class ReportCard
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        //IPerson teacher;
       public Dictionary<string, int?> StudentsLessonsRates;

        public ReportCard(string studentName, string courseName, Dictionary<string, int?> studentsLessonsRates)
        {
            StudentName = studentName;
            CourseName = courseName;
            StudentsLessonsRates = studentsLessonsRates;
        }
    }
}
