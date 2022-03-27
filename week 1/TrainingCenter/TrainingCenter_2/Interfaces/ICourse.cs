using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Classes;

namespace TrainingCenter.Interfaces
{
    public interface ICourse
    {
        string CourseName { get; set; }
   /*     public ITeacher CourseTeacher { get; set; }
        public List<IStudent> CourseStudents { get; set; }*/
        List<ReportCard> Lessons { get; set; }
    }
}
