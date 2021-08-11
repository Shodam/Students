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
        [Required(ErrorMessage = "Student Id is required.")]
        [Column("StudentID")]
        public int StudentId { get; set; }
        
        [Required(ErrorMessage = "First name is required.")]
        [Column("FirstName")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required.")] 
        [Column("LastName")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "GPA is required.")] 
        [Column("GPA")]
        public double Gpa { get; set; }
    }
}