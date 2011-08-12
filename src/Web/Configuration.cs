namespace OpenSurvey.Web
{
    using System;
    using OpenRasta.Configuration;
    using OpenSurvey.Web.Resources;
    using OpenSurvey.Web.Handlers;
    using Castle.Windsor;
    using OpenRasta.DI;
    using OpenRasta.DI.Windsor;

    public class Configuration : IConfigurationSource, IDependencyResolverAccessor
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has
                    .ResourcesOfType<HomeResource>()
                    .AtUri("/home")
                    .And.AtUri("/")
                    .HandledBy<HomeHandler>()
                    .RenderedByAspx("~/Views/HomeView.aspx")
                    ;
                ResourceSpace.Has
                    .ResourcesOfType<NewSurveyResource>()
                    .AtUri("/survey/new")
                    .HandledBy<NewSurveyHandler>()
                    .RenderedByAspx("~/Views/AddSurvey.aspx");
                    
                ResourceSpace.Has
                    .ResourcesOfType<SurveyResource>()
                    .AtUri("/survey/{title}")
                    .HandledBy<SurveyHandler>()
                    .RenderedByAspx(new
                    {
                        index="~/Views/ShowSurvey.aspx"
                    });
            }
        }

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
            container = new WindsorContainer();

            return container;
        }

        public IDependencyResolver Resolver
        {
            get { return new WindsorDependencyResolver(Container); }
        }
    }
}