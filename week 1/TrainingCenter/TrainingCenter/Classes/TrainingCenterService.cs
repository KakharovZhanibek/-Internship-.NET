using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Classes
{
    public class TrainingCenterService
    {
        public List<ITeacher> TrainingCenterTeachers;
        public List<IStudent> TrainingCenterStudents;
        public List<ICourse> TrainingCenterCourses;

        public TrainingCenterService()
        {
            TrainingCenterTeachers = new List<ITeacher>();
            TrainingCenterStudents = new List<IStudent>();
            TrainingCenterCourses = new List<ICourse>();
        }

        public void AddTeacherToCenter(ITeacher teacher)
        {
            if (teacher == null)
                throw new NullReferenceException();

            TrainingCenterTeachers.Add(teacher);
        }
        public void AddCourseToCenter(ICourse course)
        {
            if (course == null)
                throw new NullReferenceException();

            TrainingCenterCourses.Add(course);
        }
        public void AddStudentToCenter(IStudent student)
        {
            if (student == null)
                throw new NullReferenceException();

            TrainingCenterStudents.Add(student);
        }

        public void AddStudentToCourse(IStudent student, ICourse course)
        {
            if (student == null || course == null)
                throw new NullReferenceException();

            TrainingCenterStudents.Find(x => x.Equals(student)).Courses.Add(course);

            TrainingCenterCourses.Find(x => x.Equals(course)).CourseStudents.Add(student);
        }
        public void AssignTeacherToCourse(ITeacher teacher, ICourse course)
        {
            if (teacher == null)
                throw new NullReferenceException();

            TrainingCenterTeachers.Find(x => x.Equals(teacher)).Courses.Add(course);
            course.CourseTeacher = teacher;
        }
        public void AddLessonToCourse(ICourse course, Lesson lesson)
        {
            if (course == null || lesson == null)
                throw new NullReferenceException();
            course.Lessons.Add(lesson);
        }
        public void SummorizeCourse(ICourse course)
        {
            foreach (IStudent student in course.CourseStudents)
            {
                int averageFinalRate = 0;
                foreach (Lesson lesson in course.Lessons)
                {
                    averageFinalRate += lesson.StudentsLessonsResults[student];
                }
                averageFinalRate = averageFinalRate / course.Lessons.Count;
                course.StudentsCourseFinalRate.Add(student, averageFinalRate);
            }
        }
    }
}
