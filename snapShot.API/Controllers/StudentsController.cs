using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace snapShot.API.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] students = new string[] { "John", "Jane", "Mark", "Entity", "David" };
            return Ok(students);
        }
    }
}
