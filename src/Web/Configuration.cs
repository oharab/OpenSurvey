namespace OpenSurvey.Web
{
    using System;
    using OpenRasta.Configuration;
    using OpenSurvey.Web.Resources;
    using OpenSurvey.Web.Handlers;

    public class Configuration:IConfigurationSource
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
            }
        }
    }
}