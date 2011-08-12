namespace OpenSurvey.Web.Handlers
{
    using System;
    using OpenSurvey.Web.Resources;
    using OpenRasta.Web;
    using OpenSurvey.Core.Repositories;

    public class SurveyHandler
    {
        private readonly ISurveyRepository repository;
        
        public SurveyHandler(ISurveyRepository repository)
        {
            this.repository = repository;
        }

        public SurveyResource Get(int id)
        {
            var s = repository.GetSurvey(id);
            return new SurveyResource { Name = s.Name, Title = s.Title, Description = s.Description };
        }


    }
}