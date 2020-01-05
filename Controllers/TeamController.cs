using Microsoft.AspNetCore.Mvc;

namespace PredictorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService) => _teamService = teamService;

        [HttpGet]
        [Route("teams")]
        public ActionResult GetTeams()
        {
            return Ok(_teamService.GetTeams());
        }
    }
}