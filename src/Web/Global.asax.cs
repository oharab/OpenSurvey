namespace OpenSurvey.Web
{
    using System;
    using Castle.Windsor;
    using OpenRasta.DI;
    using Castle.Facilities.Logging;
    using Castle.Services.Logging.Log4netIntegration;
    using OpenSurvey.Persistence.NHibernate.Configuration;
    using Castle.MicroKernel.Registration;
    using OpenRasta.DI.Windsor;

    public class Global : System.Web.HttpApplication, IContainerAccessor, IDependencyResolverAccessor
    {

        IWindsorContainer container;
        public IWindsorContainer Container
        {
            get
            {
                if (container == null)
                    container = ConfigureContainer();
                return container;
            }
        }

        private IWindsorContainer ConfigureContainer()
        {
            container = new WindsorContainer()
                        .AddFacility<LoggingFacility>("loggingFacility", f => f.LogUsing<Log4netFactory>().WithAppConfig())
                        .Install(new NHibernateInstaller())
                        .Register(AllTypes.FromThisAssembly()
                                .Where(t => t.Namespace.EndsWith(".Resources"))
                                )
                        ;
            return container;
        }

        public IDependencyResolver Resolver
        {
            get { return new WindsorDependencyResolver(Container); }
        }
    }
}