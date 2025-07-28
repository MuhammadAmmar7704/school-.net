using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.Id) return BadRequest();
            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
