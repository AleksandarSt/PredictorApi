using System.Collections.Generic;
using System.Linq;
using PredictorApi.Layer1;

public interface ITeamService
{
    List<Team> GetTeams();
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
}