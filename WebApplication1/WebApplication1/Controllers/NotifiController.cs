using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Domain.Models;
using DataAccess.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifiController : ControllerBase
    {
        public RolandContext Context { get; }

        public NotifiController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Notification> Notification = Context.Notifications.ToList();
            return Ok(Notification);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Notification? Notification = Context.Notifications.Where(x => x.NotificationId == id).FirstOrDefault();
            if (Notification == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Notification);
        }

        [HttpPost]
        public IActionResult Add(Notification Notification)
        {
            Context.Notifications.Add(Notification);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Notification Notification)
        {
            Context.Notifications.Update(Notification);
            Context.SaveChanges();
            return Ok(Notification);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Notification? Notification = Context.Notifications.Where(x => x.NotificationId == id).FirstOrDefault();
            Context.Notifications.Remove(Notification);
            Context.SaveChanges();
            return Ok();
        }
    }
}