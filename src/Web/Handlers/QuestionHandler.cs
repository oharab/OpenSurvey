namespace OpenSurvey.Web.Handlers
{
    using System;
using OpenRasta.Web;
    using OpenSurvey.Web.Resources;

    public class QuestionHandler
    {

        public OperationResult Post(SurveyResource survey, QuestionResource question)
        {
            return new OperationResult.SeeOther { RedirectLocation = survey.CreateUri("edit") };
        }
    }
}