using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MvcToDos.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace MvcToDos.Util.Extensions
{
    public class FluentNHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString(
                                builder => builder.FromConnectionStringWithKey("Teendok")).ShowSql()
                                )
                        .Mappings(m=>m.FluentMappings
                            .AddFromAssemblyOf<Teendo>())
                        .ExposeConfiguration( cfg => new SchemaExport(cfg).Create(false, false))
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}