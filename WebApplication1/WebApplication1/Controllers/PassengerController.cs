using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Domain.Models;
using DataAccess.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        public RolandContext Context { get; }

        public PassengerController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Passenger> Passenger = Context.Passengers.ToList();
            return Ok(Passenger);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Passenger? Passenger = Context.Passengers.Where(x => x.PassengerId == id).FirstOrDefault();
            if (Passenger == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Passenger);
        }

        [HttpPost]
        public IActionResult Add(Passenger Passenger)
        {
            Context.Passengers.Add(Passenger);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Passenger Passenger)
        {
            Context.Passengers.Update(Passenger);
            Context.SaveChanges();
            return Ok(Passenger);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Passenger? Passenger = Context.Passengers.Where(x => x.PassengerId == id).FirstOrDefault();
            Context.Passengers.Remove(Passenger);
            Context.SaveChanges();
            return Ok();
        }
    }
}