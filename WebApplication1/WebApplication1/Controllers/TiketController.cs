using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiketController : ControllerBase
    {
        public RolandContext Context { get; }

        public TiketController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ticket> Ticket = Context.Tickets.ToList();
            return Ok(Ticket);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ticket? Ticket = Context.Tickets.Where(x => x.TicketId == id).FirstOrDefault();
            if (Ticket == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Ticket);
        }

        [HttpPost]
        public IActionResult Add(Ticket Ticket)
        {
            Context.Tickets.Add(Ticket);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Ticket Ticket)
        {
            Context.Tickets.Update(Ticket);
            Context.SaveChanges();
            return Ok(Ticket);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Ticket? Ticket = Context.Tickets.Where(x => x.TicketId == id).FirstOrDefault();
            Context.Tickets.Remove(Ticket);
            Context.SaveChanges();
            return Ok();
        }
    }
}