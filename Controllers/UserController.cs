using System;
using Microsoft.AspNetCore.Mvc;
using PredictorApi.Layer1;

namespace PredictorApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class UserController : Controller 
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpGet]
        public ActionResult GetUserById (int userId) 
        {
            return Ok(_userService.GetUserById(userId));    
        }

        [HttpGet]
        [Route("users")]
        public ActionResult GetUSers()
        {
            return Ok(_userService.GetUsers());
        }
    }
}