namespace OpenSurvey.Persistence.NHibernate.Configuration
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Facilities.NHibernateIntegration;
    using OpenSurvey.Core.Repositories;
    using OpenSurvey.Persistence.NHibernate.Repositories;
    using Castle.Facilities.AutoTx;

    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container
            .AddFacility<TransactionFacility>("autoTxFacility")
            .AddFacility<NHibernateFacility>("nhibnernateFacility", cfg => cfg.ConfigurationBuilder<FluentConfigurationBuilder>())
            .Register(
                Component.For<ISurveyRepository>()
                    .ImplementedBy<NHibernateSurveyRepository>()
                    .LifeStyle.PerWebRequest
            )
            ;
        }
    }
}
