using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Task_2
{
    class Student
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public double AverageGrade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=StudentsDB;Integrated Security=True";

            string query = "SELECT Name, Course, AverageGrade FROM Students";

            List<Student> filteredStudents = new List<Student>();

            Func<Student, bool> filterByCourse = s => s.Course == 3;
            Func<Student, bool> filterByAverageGrade = s => s.AverageGrade >= 4.5;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    int course = reader.GetInt32(1);
                    double averageGrade = reader.GetDouble(2);

                    Student student = new Student
                    {
                        Name = name,
                        Course = course,
                        AverageGrade = averageGrade
                    };

                    if (filterByCourse(student) && filterByAverageGrade(student))
                    {
                        filteredStudents.Add(student);
                    }
                }

                reader.Close();
                connection.Close();
            }

            Console.WriteLine("Filtered Students:");
            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.Name} - Course: {student.Course}, Average Grade: {student.AverageGrade}");
            }

            Console.ReadKey();
        }
    }
}
