using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Npgsql;
using Dapper;

namespace db_exercise
{
    internal class PostgresDataAccess
    {
        public static List<StudentModel> GetAllStudents()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudentModel>("SELECT * FROM dac_student ORDER BY id", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<CourseModel> GetAllCourses()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CourseModel>("SELECT * FROM dac_course ORDER BY start_date desc", new DynamicParameters());
                return output.ToList();
            }
        }

        public static bool CreateNewStudent(StudentModel student)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO dac_student (first_name, last_name, email, age, password) VALUES (@first_name, @last_name, @email, @age, @password)", student);
                return true;

            }
        }

        public static bool CreateNewCourse(CourseModel course)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO dac_course (name, points, start_date, end_date) VALUES (@name, @points, @start_date, @end_date)", course);
                return true;
            }
        }

        public static bool ChangeStudentPasswd(int id, string passwd)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_student SET password = '{passwd}' WHERE id = {id}");
                return true;
            }
        }

        public static CourseModel GetCourseById(int id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<CourseModel>($"SELECT * FROM dac_course where id = {id}");
                return output.ToList().First();
            }
        }

        public static bool EditAllCourseInfo(CourseModel edit)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_course SET name = @name, points = @points, start_date = @start_date, end_date = @end_date WHERE id = @id", edit);
                return true;
            }
        }

        public static bool EditCourseName(int id, string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_course SET name = '{name}' WHERE id = {id}");
                return true;
            }
        }

        public static bool EditCoursePoints(int id, int points)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_course SET points = {points} WHERE id = {id}");
                return true;
            }
        }

        public static bool EditCourseStartDate(int id, DateTime startDate)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_course SET start_date = '{startDate}' WHERE id = {id}");
                return true;
            }
        }

        public static bool EditCourseEndDate(int id, DateTime endDate)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE dac_course SET end_date = '{endDate}' WHERE id = {id}");
                return true;
            }
        }

        public static bool DeleteCourse(int id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($"DELETE FROM dac_course WHERE id = {id}");
                return true;

            }
        }

        private static string LoadConnectionString(string id = "default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}