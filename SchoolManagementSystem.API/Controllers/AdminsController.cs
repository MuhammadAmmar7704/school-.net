using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAll()
        {
            return Ok(_adminService.GetAllAdmins());
        }

        [HttpGet("{id}")]
        public ActionResult<Admin> GetById(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            _adminService.AddAdmin(admin);
            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Admin admin)
        {
            if (id != admin.Id) return BadRequest();
            _adminService.UpdateAdmin(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adminService.DeleteAdmin(id);
            return NoContent();
        }
    }
}
