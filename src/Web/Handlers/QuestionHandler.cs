namespace OpenSurvey.Web.Handlers
{
    using System;
using OpenRasta.Web;
    using OpenSurvey.Web.Resources;
using OpenSurvey.Core.Repositories;
    using OpenSurvey.Core.Model;

    public class QuestionHandler
    {
        private readonly ISurveyRepository surveyRepository;
        public QuestionHandler(ISurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        public OperationResult Get(int surveyId)
        {
            return new OperationResult.OK( new NewQuestionResource { SurveyID = surveyId });
        }


        public OperationResult Post(int surveyId, QuestionResource question)
        {
            var s = surveyRepository.GetSurvey(surveyId);
            s.Questions.Add(new Question { QuestionText = question.QuestionText });
            surveyRepository.Update(s);

            var r = new SurveyResource { Id = s.Id, Name = s.Name, Title = s.Title, Description = s.Description };
            

            return new OperationResult.SeeOther { RedirectLocation = s.CreateUri() };
        }
    }
}