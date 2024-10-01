using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Domain.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharterController : ControllerBase
    {
        public RolandContext Context { get; }

        public CharterController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Charter> Charter = Context.Charters.ToList();
            return Ok(Charter);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Charter? Charter = Context.Charters.Where(x => x.CharterId == id).FirstOrDefault();
            if (Charter == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Charter);
        }

        [HttpPost]
        public IActionResult Add(Charter Charter)
        {
            Context.Charters.Add(Charter);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Charter Charter)
        {
            Context.Charters.Update(Charter);
            Context.SaveChanges();
            return Ok(Charter);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Charter? Charter = Context.Charters.Where(x => x.CharterId == id).FirstOrDefault();
            Context.Charters.Remove(Charter);
            Context.SaveChanges();
            return Ok();
        }
    }
}