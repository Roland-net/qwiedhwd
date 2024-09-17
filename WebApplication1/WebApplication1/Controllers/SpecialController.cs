using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialController : ControllerBase
    {
        public RolandContext Context { get; }

        public SpecialController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<SpecialService> SpecialService = Context.SpecialServices.ToList();
            return Ok(SpecialService);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SpecialService? SpecialService = Context.SpecialServices.Where(x => x.ServiceId == id).FirstOrDefault();
            if (SpecialService == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(SpecialService);
        }

        [HttpPost]
        public IActionResult Add(SpecialService SpecialService)
        {
            Context.SpecialServices.Add(SpecialService);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(SpecialService SpecialService)
        {
            Context.SpecialServices.Update(SpecialService);
            Context.SaveChanges();
            return Ok(SpecialService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            SpecialService? SpecialService = Context.SpecialServices.Where(x => x.ServiceId == id).FirstOrDefault();
            Context.SpecialServices.Remove(SpecialService);
            Context.SaveChanges();
            return Ok();
        }
    }
}