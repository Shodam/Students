using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var context = HttpContext.RequestServices.GetService(typeof(StudentContext)) as StudentContext;
            return View(context.GetAllStudents());
        }
    }
}