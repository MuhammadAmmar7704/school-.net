using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Teacher")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Grade grade)
        {
            _gradeService.AddGrade(grade);
            return Ok();
        }

        [HttpGet("student/{studentId}")]
        public ActionResult<IEnumerable<Grade>> GetByStudent(int studentId)
        {
            return Ok(_gradeService.GetGradesByStudent(studentId));
        }

        [HttpGet("subject/{subject}")]
        public ActionResult<IEnumerable<Grade>> GetBySubject(string subject)
        {
            return Ok(_gradeService.GetGradesBySubject(subject));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Grade>> GetAll()
        {
            return Ok(_gradeService.GetAllGrades());
        }
    }
}
