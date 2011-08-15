namespace OpenSurvey.Web
{
    using System;
    using OpenRasta.Configuration;
    using OpenSurvey.Web.Resources;
    using OpenSurvey.Web.Handlers;
    using OpenRasta.Web.UriDecorators;
    

    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.UriDecorator<HttpMethodOverrideUriDecorator>();
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
                    .ResourcesOfType<NewQuestionResource>()
                    .AtUri("/survey/{surveyId}/questions")
                    .HandledBy<QuestionHandler>()
                    .RenderedByUserControl("~/Views/Controls/AddNewQuestion.ascx")
                    ;

                ResourceSpace.Has
                    .ResourcesOfType<SurveyResource>()
                    .AtUri("/survey/{id}")
                    .And.AtUri("/survey/{id}/edit").Named("edit")
                    .HandledBy<SurveyHandler>()
                    .RenderedByAspx(new
                    {
                        index = "~/Views/ShowSurvey.aspx",
                        edit = "~/Views/EditSurvey.aspx"
                    });
            }
        }
    }
}