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
    }
}