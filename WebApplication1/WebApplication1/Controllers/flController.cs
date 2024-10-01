using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using DataAccess.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class flController : ControllerBase
    {
        public RolandContext Context { get; }

        public flController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Flight> Flight = Context.Flights.ToList();
            return Ok(Flight);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Flight? Flight = Context.Flights.Where(x => x.FlightId == id).FirstOrDefault();
            if (Flight == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Flight);
        }

        [HttpPost]
        public IActionResult Add(Flight Flight)
        {
            Context.Flights.Add(Flight);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Flight Flight)
        {
            Context.Flights.Update(Flight);
            Context.SaveChanges();
            return Ok(Flight);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Flight? Flight = Context.Flights.Where(x => x.FlightId == id).FirstOrDefault();
            Context.Flights.Remove(Flight);
            Context.SaveChanges();
            return Ok();
        }
    }
}