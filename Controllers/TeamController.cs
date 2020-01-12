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
        public IActionResult UpdateTeam([FromBody] TeamDto teamDto)
        {
            //return Ok(_teamService.Save(new FormData(form))

            return Ok(_teamService.SaveTeam(teamDto));
        }

        /*
        [HttpPost]
        public IActionResult Insert(IFormCollection form)
        {
            if (!_channelsService.Security.CanManageChannels)
                return Challenge();
            return Ok(_channelsService.Save(new FormData(form)));
        }
        */
        /*[HttpPost]
         public IActionResult GetAnswer([FromBody] Answer data)
        {
            var answer = new Answer()
            {
                MailInfoId = data.Id,
                IsApproved = data.IsApproved,
                Reason = data.Reason,
                Comment = data.Comment,
                IsSpecialPriceList = data.IsSpecialPriceList
            };

            return Ok(_mailService.GetAnswer(answer));
        } */

    }
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}