namespace OpenSurvey.Persistence.NHibernate.Configuration
{
    using System;
    using Castle.Windsor;
    using Castle.Facilities.NHibernateIntegration;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;

    public partial class ConfigureContainer
    {
        public static void ConfigurePersistence(IWindsorContainer container)
        {
            container
            .AddFacility<NHibernateFacility>("nhibnernateFacility", cfg => cfg.ConfigurationBuilder<FluentConfigurationBuilder>())
            ;
        }

    }
}
