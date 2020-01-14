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

        [HttpPost]
        [Route("update-team")]
        public IActionResult UpdateTeam([FromBody] TeamDto teamDto)
        {
            return Ok(_teamService.SaveTeam(teamDto));
        }

        [HttpPost]
        [Route("add-team")]
        public IActionResult AddTeam([FromBody] TeamDto teamDto)
        {
            return Ok(_teamService.SaveTeam(teamDto));
        }
    }
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}