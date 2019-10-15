using System;
using System.Collections.Generic;

namespace MVC.DataAccess
{
    public class DataContainer
    {
        public static List<Student> Students = new List<Student>();
        public static List<School> Schools = new List<School>();
        public static List<Grade> Grades = new List<Grade>();

        public static void InitializationData()
        {
            InitializationSchool(3);
            InitializationGrade(9);
            InitializationStudent();
        }

        private static void InitializationStudent()
        {
            foreach (Grade grade in Grades)
            {
                for (int studentIndex = 0; studentIndex < new Random(Guid.NewGuid().GetHashCode()).Next(5, 30); studentIndex++)
                {
                    Student student = new Student
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = $"Student-{Guid.NewGuid().GetHashCode()}",
                        Address = $"Address-{new Random(Guid.NewGuid().GetHashCode()).Next()}",
                        Age = new Random(Guid.NewGuid().GetHashCode()).Next(6, 15),
                        School = grade.School,
                        Grade = grade
                    };

                    Student.Add(student);
                    grade.School.Students.Add(student);
                }
            }
        }

        private static void InitializationGrade(int gradeCount)
        {
            foreach (School school in Schools)
            {
                for (int gradeIndex = 1; gradeIndex <= gradeCount; gradeIndex++)
                {
                    Grade grade = new Grade
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = $"Grade-{new Random(Guid.NewGuid().GetHashCode()).Next(1, 9)}",
                        School = school
                    };

                    Grades.Add(grade);
                    school.Grades.Add(grade);
                }
            }
        }

        private static void InitializationSchool(int schoolCount)
        {
            for (int schoolIndex = 1; schoolIndex <= schoolCount; schoolIndex++)
            {
                School school = new School
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"School-{schoolIndex}",
                    Grades = new List<Grade>(),
                    Students = new List<Student>()
                };

                Schools.Add(school);
            }
        }
    }
}