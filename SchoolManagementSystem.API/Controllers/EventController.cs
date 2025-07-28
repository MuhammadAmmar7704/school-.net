using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Teacher")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService) { _eventService = eventService; }

        [HttpPost]
        public IActionResult Add([FromBody] Event ev)
        {
            _eventService.AddEvent(ev);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            return Ok(_eventService.GetAllEvents());
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetById(int id)
        {
            var ev = _eventService.GetEventById(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Event ev)
        {
            if (id != ev.Id) return BadRequest();
            _eventService.UpdateEvent(ev);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _eventService.DeleteEvent(id);
            return NoContent();
        }
    }
}
