using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PredictorApi.Controllers;
using PredictorApi.Layer1;

public interface ITeamService
{
    List<Team> GetTeams();
    Task SaveTeam(TeamDto teamDto);
}

public class TeamService : ITeamService
{
    public List<Team> GetTeams()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (session.BeginTransaction())
            {
                var users = session.Query<Team>().Take(10).ToList();

                return users;
            }
        }
    }

    public Task SaveTeam(TeamDto teamDto)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (session.BeginTransaction())
            {
                var id = teamDto.Id;
                Team team;
                if (id == 0)
                {
                    team = new Team();
                }
                else
                {
                    team = session.Query<Team>().Where(x => x.Id == id).First();
                }

                team.DisplayName = teamDto.DisplayName;
                team.Name = teamDto.Name;

                session.SaveOrUpdate(team);
                session.Transaction.Commit();

                return Task.CompletedTask;
            }
        }
    }
}