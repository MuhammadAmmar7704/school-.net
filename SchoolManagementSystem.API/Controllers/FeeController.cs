using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class FeeController : ControllerBase
    {
        private readonly IFeeService _feeService;
        public FeeController(IFeeService feeService) { _feeService = feeService; }

        [HttpPost("generate")]
        public IActionResult Generate([FromBody] FeeChallan challan)
        {
            _feeService.GenerateFeeChallan(challan.StudentId, challan.Amount, challan.DueDate);
            return Ok();
        }

        [HttpPost("markpaid/{id}")]
        public IActionResult MarkPaid(int id, [FromBody] DateTime paidDate)
        {
            _feeService.MarkFeeAsPaid(id, paidDate);
            return Ok();
        }

        [HttpGet("student/{studentId}")]
        public ActionResult<IEnumerable<FeeChallan>> GetByStudent(int studentId)
        {
            return Ok(_feeService.GetFeeChallansByStudent(studentId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<FeeChallan>> GetAll()
        {
            return Ok(_feeService.GetAllFeeChallans());
        }
    }
}
