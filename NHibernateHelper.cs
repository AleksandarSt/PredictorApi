using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using PredictorApi.Layer2;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
            {
                InitilizeSessionFactory();
            }

            return _sessionFactory;
        }
    }

    private static void InitilizeSessionFactory()
    {
        _sessionFactory = Fluently
        .Configure()
        .Database(
            MySQLConfiguration.Standard
            .Driver<MySqlDataDriver>()
            .Dialect<MySQLDialect>()
            .ConnectionString
            (
                c => c
                .Server("localhost; Port=3306")//.Server("78.83.59.100; Port=3307")
                .Database("test_db")//.Database("soccer")
                .Username("test_user")//.Username("web")
                .Password("test_user")//.Password("w3bsql")
            )
            .ShowSql()
            .FormatSql()
        )
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
        .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}