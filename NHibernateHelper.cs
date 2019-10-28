using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PredictorApi.Layer1;

public class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory 
    {
        get {
            if(_sessionFactory==null)
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
        .Database(MySQLConfiguration.Standard.ShowSql()
        .ConnectionString("Server=localhost; Port=3306;Database=test_db; Uid=root; Pwd=;"))
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
        .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }
}
