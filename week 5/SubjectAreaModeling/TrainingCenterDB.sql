CREATE TABLE Courses(
Course_Id INT PRIMARY KEY IDENTITY,
Course_Name NVARCHAR(100) NOT NULL
)

CREATE TABLE Teachers(
Teacher_Id INT PRIMARY KEY IDENTITY,
Teacher_Name NVARCHAR(100) NOT NULL,
Teacher_SurName NVARCHAR(100) NOT NULL,
)

CREATE TABLE Students(
Student_Id INT PRIMARY KEY IDENTITY,
Student_Name NVARCHAR(100) NOT NULL,
Student_SurName NVARCHAR(100) NOT NULL,
)

CREATE TABLE Lessons(
Lesson_Id INT PRIMARY KEY IDENTITY,
Lesson_Name NVARCHAR(100) NOT NULL,
Course_Id INT FOREIGN KEY REFERENCES Courses(Course_Id)
)

CREATE TABLE StudentsCourses(
Student_Course_Id INT PRIMARY KEY IDENTITY,
Student_Id INT FOREIGN KEY REFERENCES Students(Student_Id),
Course_Id INT FOREIGN KEY REFERENCES Courses(Course_Id)
)

CREATE TABLE StudentsLessonsScores(
StudentLessonId INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Student_Id),
LessonId INT FOREIGN KEY REFERENCES Lessons(Lesson_Id),
Score INT NOT NULL CHECK(Score>=0 AND Score<=100)
)

INSERT INTO Courses VALUES('C#')
INSERT INTO Courses VALUES('Java')
INSERT INTO Courses VALUES('DataBases')

INSERT INTO Teachers VALUES('Sam','Dallas')
INSERT INTO Teachers VALUES('Finnegan','Leston')

INSERT INTO Students VALUES('Tomas','Shelby')
INSERT INTO Students VALUES('Freddy','Crueger')
INSERT INTO Students VALUES('Jason','Vurhiz')

INSERT INTO StudentsCourses VALUES(1,1)
INSERT INTO StudentsCourses VALUES(1,3)
INSERT INTO StudentsCourses VALUES(2,2)
INSERT INTO StudentsCourses VALUES(2,3)
INSERT INTO StudentsCourses VALUES(1,1)

INSERT INTO Lessons VALUES('Intro to C#',1)
INSERT INTO Lessons VALUES('Data types in C#',1)
INSERT INTO Lessons VALUES('Arrays in C#',1)
INSERT INTO Lessons VALUES('Data srtuctures in C#',1)

INSERT INTO Lessons VALUES('Intro to Java',2)
INSERT INTO Lessons VALUES('Data types in Java',2)
INSERT INTO Lessons VALUES('Arrays in Java',2)
INSERT INTO Lessons VALUES('Data srtuctures in Java',2)

INSERT INTO Lessons VALUES('Intro to Databases',3)
INSERT INTO Lessons VALUES('DDL',3)
INSERT INTO Lessons VALUES('Tables',3)
INSERT INTO Lessons VALUES('DML',3)

INSERT INTO StudentsLessonsScores VALUES(1,1,94)
INSERT INTO StudentsLessonsScores VALUES(1,2,84)
INSERT INTO StudentsLessonsScores VALUES(1,3,99)
INSERT INTO StudentsLessonsScores VALUES(1,4,82)

INSERT INTO StudentsLessonsScores VALUES(2,5,97)
INSERT INTO StudentsLessonsScores VALUES(2,6,86)
INSERT INTO StudentsLessonsScores VALUES(2,7,99)
INSERT INTO StudentsLessonsScores VALUES(2,8,80)

INSERT INTO StudentsLessonsScores VALUES(3,9,99)
INSERT INTO StudentsLessonsScores VALUES(3,10,95)
INSERT INTO StudentsLessonsScores VALUES(3,11,93)
INSERT INTO StudentsLessonsScores VALUES(3,12,90)

INSERT INTO StudentsLessonsScores VALUES(1,9,99)
INSERT INTO StudentsLessonsScores VALUES(1,10,99)
INSERT INTO StudentsLessonsScores VALUES(1,11,100)
INSERT INTO StudentsLessonsScores VALUES(1,12,97)

INSERT INTO StudentsLessonsScores VALUES(2,9,99)
INSERT INTO StudentsLessonsScores VALUES(2,10,75)
INSERT INTO StudentsLessonsScores VALUES(2,11,70)
INSERT INTO StudentsLessonsScores VALUES(2,12,84)

SELECT s.Student_Name,l.Lesson_Name,sls.Score 
FROM students s, Lessons l, StudentsLessonsScores sls 
WHERE s.Student_Id=sls.StudentId and l.Lesson_Id=sls.LessonId

SELECT s.Student_Name,c.Course_Name,AVG(sls.Score) as CourseScore
FROM students s, Lessons l, StudentsLessonsScores sls, Courses c
WHERE s.Student_Id=sls.StudentId and l.Lesson_Id=sls.LessonId and l.Course_Id=c.Course_Id
GROUP BY sls.StudentId,s.Student_Name,c.Course_Name
