using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        public RolandContext Context { get; }

        public AirportController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Airport> Airport = Context.Airports.ToList();
            return Ok(Airport);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Airport? Airport = Context.Airports.Where(x => x.AirportId == id).FirstOrDefault();
            if (Airport == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Airport);
        }

        [HttpPost]
        public IActionResult Add(Airport Airport)
        {
            Context.Airports.Add(Airport);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Airport Airport)
        {
            Context.Airports.Update(Airport);
            Context.SaveChanges();
            return Ok(Airport);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Airport? Airport = Context.Airports.Where(x => x.AirportId == id).FirstOrDefault();
            Context.Airports.Remove(Airport);
            Context.SaveChanges();
            return Ok();
        }
    }
}