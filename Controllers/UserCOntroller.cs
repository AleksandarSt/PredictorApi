using Microsoft.AspNetCore.Mvc;
using PredictorApi.Layer1;
using System;

namespace PredictorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult GetUSerById(int userId)
        {
            var user= new User {
                Id=userId,
                Name="test",
                DateOfBirth= DateTime.Now
            };

            return Ok(user);
        }
    }
}