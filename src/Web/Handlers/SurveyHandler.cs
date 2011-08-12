namespace OpenSurvey.Web.Handlers
{
    using System;
    using OpenSurvey.Web.Resources;
    using OpenRasta.Web;

    public class SurveyHandler
    {

        public SurveyResource Get(string title)
        {
            return new SurveyResource { Title = title };
        }

    }
}