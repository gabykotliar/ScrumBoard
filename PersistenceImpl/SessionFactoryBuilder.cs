﻿using System;
using System.Reflection;
using Common.Persistence.NHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;
using ScrumBoard.Domain;

namespace ScrumBoard.Persistence.Implementation
{
    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        public ISessionFactory GetSessionFactory()
        {
            var autoMappedModel = AutoMap.AssemblyOf<Project>().Where(IsNotResource).Where(type => type != typeof(ProductBacklog));

            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();

            var cfg = Fluently.Configure(configuration)
                              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                              .Mappings(m => m.AutoMappings.Add(autoMappedModel))
                              .BuildConfiguration();

            return cfg.BuildSessionFactory();
        }

        private static bool IsNotResource(Type type)
        {
            return !type.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true);
        }
    }
}
