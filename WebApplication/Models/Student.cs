using System.Data;
using System.Threading.Tasks;
using System;    
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using MySql.Data.MySqlClient;
namespace WebApplication.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public double Gpa { get; set; }
    }
}