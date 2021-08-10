using MySql.Data.MySqlClient;
using System;    
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class StudentContext
    {
        public string ConnectionString { get; set; }    
    
        public StudentContext(string connectionString)    
        {    
            this.ConnectionString = connectionString;    
        }    
    
        private MySqlConnection GetConnection()    
        {    
            return new MySqlConnection(ConnectionString);    
        }
        
        public List<Student> GetAllStudents()
        {
            var list = new List<Student>();
            using MySqlConnection conn = GetConnection();
            conn.Open();
            var cmd = new MySqlCommand("select * from students", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student(){
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    FirstName = reader["First Name"].ToString(),
                    LastName = reader["Last Name"].ToString(),
                    Gpa = Convert.ToDouble(reader["Gpa"])
                });
            }

            return list;
        }
    }
}