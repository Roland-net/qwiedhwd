using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Domain.Models;
using DataAccess.Models;

namespace SocNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public RolandContext Context { get; }

        public ReviewController(RolandContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> Review = Context.Reviews.ToList();
            return Ok(Review);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Review? Review = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (Review == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Review);
        }

        [HttpPost]
        public IActionResult Add(Review Review)
        {
            Context.Reviews.Add(Review);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Review Review)
        {
            Context.Reviews.Update(Review  );
            Context.SaveChanges();
            return Ok(Review);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Review? Review = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            Context.Reviews.Remove(Review);
            Context.SaveChanges();
            return Ok();
        }
    }
}