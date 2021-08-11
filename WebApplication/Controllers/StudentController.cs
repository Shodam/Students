using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentList(string searchString)
        {
            var list = new List<Student>();
            using var con = new MySqlConnection("server=localhost;port=3306;database=studentdatabase;user=shodam;password=Evelash4482519");
            con.Open();
            var cmd = new MySqlCommand("SELECT * FROM students", con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student(){
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Gpa = Convert.ToDouble(reader["GPA"])
                });
            }
            return View(list);
        }
        
        public IActionResult AddStudentForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudentForm(Student stud)
        {
            try
            {
                int studentId = Convert.ToInt32(stud.StudentId);
                String firstname = stud.FirstName;
                String lastname = stud.LastName;
                double gpa = Convert.ToDouble(stud.Gpa);
                String command = $"INSERT INTO students VALUES ({studentId},'{firstname}','{lastname}',{gpa});";
                using var con = new MySqlConnection("server=localhost;port=3306;database=studentdatabase;user=shodam;password=Evelash4482519");
                var cmd = new MySqlCommand(command, con);
                con.Open();
                using var reader = cmd.ExecuteReader();
                Console.WriteLine("Saving Data");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

    }
}