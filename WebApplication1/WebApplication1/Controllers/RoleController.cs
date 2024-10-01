using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Domain.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RolandContext Context { get; }

        public RoleController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Role> Role = Context.Roles.ToList();
            return Ok(Role);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Role? Role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (Role == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Role);
        }

        [HttpPost]
        public IActionResult Add(Role Role)
        {
            Context.Roles.Add(Role);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Role Role)
        {
            Context.Roles.Update(Role);
            Context.SaveChanges();
            return Ok(Role);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Role? Role = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            Context.Roles.Remove(Role);
            Context.SaveChanges();
            return Ok();
        }
    }
}