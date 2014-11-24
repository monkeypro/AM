using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernateLabb.NHibernate.Conventions;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using NHibernateLabb.Entities;

namespace NHibernateLabb.NHibernate
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory Instance
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = CreateSessionFactory();
                }
                return _sessionFactory;
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("DatabaseConnectionString")))
                           .Mappings(m =>
                           {
                               m.FluentMappings.Conventions.AddFromAssemblyOf<CustomForeignKeyConvention>();
                               m.FluentMappings.AddFromAssemblyOf<EntityBase>();
                           })
                           
                           .BuildSessionFactory();
        }
    }
}