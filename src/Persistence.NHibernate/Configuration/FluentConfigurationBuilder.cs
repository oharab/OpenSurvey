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
    using global::NHibernate.Tool.hbm2ddl;
    using OpenSurvey.Persistence.NHibernate.Mappings;
    using System.Reflection;


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
                        .ShowSql()
                )
                .Mappings(
                    m =>m.FluentMappings.AddFromAssemblyOf<SurveyMap>()
                )
                .ExposeConfiguration(buildSchema)
                .BuildSessionFactory();
            return configuration;
        }

        private void buildSchema(global::NHibernate.Cfg.Configuration cfg)
        {
            new SchemaExport(cfg)
                .Create(true, true);
        }


        
    }
}
