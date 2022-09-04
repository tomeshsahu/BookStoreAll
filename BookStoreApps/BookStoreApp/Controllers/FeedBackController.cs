using BusinessLayer.Interface;
using DatabaseLayer.FeedBackModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [ApiController]
    [Route("Controller")]


    public class FeedBackController : Controller
    {
        IFeedBackBL feedBackBL;
        public FeedBackController(IFeedBackBL feedbackBL)
        {
        this.feedBackBL = feedbackBL;
        }
        [HttpPost("AddFeedBack")]
        public IActionResult AddFeedBack(FeedBackPostModel feedBackPostModel)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
            int UserId = int.Parse(userId);

            var result = this.feedBackBL.AddFeedback(UserId, feedBackPostModel);
            if (result != null)
            {
                return this.Ok(new { success = true, message = " Feedback Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "FeedBack is Unsuccessfull", });
            }
        }


        [HttpGet("GetAllFeedback")]
        public IActionResult GetAllFeedback(int bookId)
        {
        
            var result = this.feedBackBL.GetAllFeedback(bookId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = " Feedback Get Successfully",data=result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "FeedBack Not Found", });
            }
        }
    }
}
