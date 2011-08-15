namespace OpenSurvey.Web.Resources
{
    using System;

    public class NewQuestionResource
    {
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public SurveyResource Survey { get; set; }
    }
}