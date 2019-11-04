using System;
using Microsoft.AspNetCore.Mvc;
using PredictorApi.Layer1;

namespace PredictorApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class UserController : Controller {
        [HttpGet]
        public ActionResult GetUserById (int userId) {

            using (var session = NHibernateHelper.OpenSession ()) {
            using (session.BeginTransaction ()) {
                    var user = session.Get<User> (userId);

                    return Ok (user);
                }
            }
        }
    }
}