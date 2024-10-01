using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HisController : ControllerBase
    {
        public RolandContext Context { get; }

        public HisController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChangeHistory> ChangeHistory = Context.ChangeHistories.ToList();
            return Ok(ChangeHistory);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ChangeHistory? ChangeHistory = Context.ChangeHistories.Where(x => x.UserId == id).FirstOrDefault();
            if (ChangeHistory == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ChangeHistory);
        }

        [HttpPost]
        public IActionResult Add(ChangeHistory ChangeHistory)
        {
            Context.ChangeHistories.Add(ChangeHistory);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ChangeHistory ChangeHistory)
        {
            Context.ChangeHistories.Update(ChangeHistory);
            Context.SaveChanges();
            return Ok(ChangeHistory);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ChangeHistory? ChangeHistory = Context.ChangeHistories.Where(x => x.ChangeId == id).FirstOrDefault();
            Context.ChangeHistories.Remove(ChangeHistory);
            Context.SaveChanges();
            return Ok();
        }
    }
}