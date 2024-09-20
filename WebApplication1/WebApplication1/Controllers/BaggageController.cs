using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggageController : ControllerBase
    {
        public RolandContext Context { get; }

        public BaggageController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Baggage> Baggage = Context.Baggages.ToList();
            return Ok(Baggage);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Baggage? Baggage = Context.Baggages.Where(x => x.BaggageId == id).FirstOrDefault();
            if (Baggage == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Baggage);
        }

        [HttpPost]
        public IActionResult Add(Baggage Baggage)
        {
            Context.Baggages.Add(Baggage);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Baggage Baggage)
        {
            Context.Baggages.Update(Baggage);
            Context.SaveChanges();
            return Ok(Baggage);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Baggage? Baggage = Context.Baggages.Where(x => x.BaggageId == id).FirstOrDefault();
            Context.Baggages.Remove(Baggage);
            Context.SaveChanges();
            return Ok();
        }
    }
}