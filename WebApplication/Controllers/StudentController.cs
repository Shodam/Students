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
                    FirstName = reader["First Name"].ToString(),
                    LastName = reader["Last Name"].ToString(),
                    Gpa = Convert.ToDouble(reader["Gpa"])
                });
            }
            return View(list);
        }
        
        public IActionResult AddStudentForm()
        {
            return View();
        }
        
    }
}