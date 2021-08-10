namespace WebApplication.Models
{
    public class Student
    {
        private StudentContext context;
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Gpa { get; set; }
    }
}