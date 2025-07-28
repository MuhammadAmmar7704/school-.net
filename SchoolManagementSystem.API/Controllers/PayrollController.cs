using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        public PayrollController(IPayrollService payrollService) { _payrollService = payrollService; }

        [HttpPost("generate")]
        public IActionResult Generate([FromBody] Payroll payroll)
        {
            _payrollService.GeneratePayroll(payroll.StaffId, payroll.Amount, payroll.PayDate);
            return Ok();
        }

        [HttpGet("staff/{staffId}")]
        public ActionResult<IEnumerable<Payroll>> GetByStaff(int staffId)
        {
            return Ok(_payrollService.GetPayrollsByStaff(staffId));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payroll>> GetAll()
        {
            return Ok(_payrollService.GetAllPayrolls());
        }
    }
}
