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

        public OperationResult Get(int id)
        {
            var s = repository.GetSurvey(id);
            if (s == null)
                return new OperationResult.NotFound();
            return new OperationResult.OK( new SurveyResource { Id=s.Id, Name = s.Name, Title = s.Title, Description = s.Description });
        }

        public OperationResult Put(SurveyResource resource)
        {
            var s = repository.GetSurvey(resource.Id);
            s.Name = resource.Name;
            s.Title = resource.Title;
            s.Description = resource.Description;
            repository.Update(s);

            return new OperationResult.SeeOther { RedirectLocation = resource.CreateUri() };
        }

        public OperationResult Post(QuestionResource questionResource)
        {
            return new OperationResult.NotFound();
        }

    }
}