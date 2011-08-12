namespace OpenSurvey.Persistence.NHibernate.Configuration
{
    using System;
    using Castle.Facilities.NHibernateIntegration;
    using Castle.Facilities.NHibernateIntegration.Builders;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Automapping;
    using OpenSurvey.Core.Model;
    using Castle.Core.Configuration;


    public class FluentConfigurationBuilder : IConfigurationBuilder
    {
        public global::NHibernate.Cfg.Configuration GetConfiguration(IConfiguration config)
        {

            var defaultConfigurationBuilder = new DefaultConfigurationBuilder();
            var configuration = defaultConfigurationBuilder.GetConfiguration(config);
            Fluently.Configure(configuration)
                .Database(
                    SQLiteConfiguration
                        .Standard
                        .ConnectionString(c => c.FromConnectionStringWithKey("OpenSurveyConnectionString"))
                )
                .Mappings(
                    m => m.AutoMappings.Add(
                        AutoMap.AssemblyOf<Survey>()
                    )
                )
                .BuildSessionFactory();
            return configuration;
        }



    }
}
