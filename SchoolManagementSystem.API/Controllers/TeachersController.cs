using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Teacher")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetAll()
        {
            return Ok(_teacherService.GetAllTeachers());
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> GetById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            _teacherService.AddTeacher(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Teacher teacher)
        {
            if (id != teacher.Id) return BadRequest();
            _teacherService.UpdateTeacher(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherService.DeleteTeacher(id);
            return NoContent();
        }
    }
}
