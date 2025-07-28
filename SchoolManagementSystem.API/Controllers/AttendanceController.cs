using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Teacher")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public IActionResult Record([FromBody] Attendance record)
        {
            _attendanceService.RecordAttendance(record.StudentId, record.Date, record.Present);
            return Ok();
        }

        [HttpGet("student/{studentId}")]
        public ActionResult<IEnumerable<Attendance>> GetByStudent(int studentId)
        {
            return Ok(_attendanceService.GetAttendanceByStudent(studentId));
        }

        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Attendance>> GetByDate(DateTime date)
        {
            return Ok(_attendanceService.GetAttendanceByDate(date));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Attendance>> GetAll()
        {
            return Ok(_attendanceService.GetAllAttendance());
        }
    }
}
