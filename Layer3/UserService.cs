using System.Collections.Generic;
using System.Linq;
using PredictorApi.Layer1;

public interface IUserService
{
    User GetUserById(int id);
    List<User> GetUsers();
}

public class UserService : IUserService
{
    public User GetUserById(int id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (session.BeginTransaction())
            {
                var user = session.Get<User>(id);

                return user;
            }
        }
    }

    public List<User> GetUsers()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (session.BeginTransaction())
            {
                var users = session.Query<User>().Take(10).ToList();

                return users;
            }
        }
    }
}