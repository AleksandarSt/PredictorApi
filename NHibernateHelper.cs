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
               .Server("78.83.59.100; Port=3307")
                .Database("soccer")
               .Username("web")
                .Password("w3bsql")

                //local setting
                /*.Server("localhost; Port=3306")
                .Database("test_db")
                .Username("test_user")
                .Password("test_user"))*/
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