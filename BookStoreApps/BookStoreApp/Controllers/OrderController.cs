using BusinessLayer.Interface;
using DatabaseLayer.OrdersModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class OrderController : Controller
    {
        IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost("AddOrder")]
         public IActionResult AddOrder(OrderPostModel orderPostModel)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = int.Parse(userId);

                var result = this.orderBL.AddOrder(UserId, orderPostModel);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Order Placed Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Order Not Placed  " });

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = int.Parse(userId);

                var result = this.orderBL.GetAllOrder(UserId);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Order Get Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Order Not Found  " });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
