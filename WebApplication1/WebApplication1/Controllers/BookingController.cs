using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public RolandContext Context { get; }

        public BookingController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Booking> Booking = Context.Bookings.ToList();
            return Ok(Booking);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Booking? Booking = Context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            if (Booking == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Booking);
        }

        [HttpPost]
        public IActionResult Add(Booking Booking)
        {
            Context.Bookings.Add(Booking);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Booking Booking)
        {
            Context.Bookings.Update(Booking);
            Context.SaveChanges();
            return Ok(Booking);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Booking? Booking = Context.Bookings.Where(x => x.BookingId == id).FirstOrDefault();
            Context.Bookings.Remove(Booking);
            Context.SaveChanges();
            return Ok();
        }
    }
}