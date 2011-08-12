namespace OpenSurvey.Web.Handlers
{
    using System;
    using OpenSurvey.Web.Resources;
    using OpenRasta.Web;
    using OpenSurvey.Core.Repositories;

    public class NewSurveyHandler
    {
        private readonly ISurveyRepository repository;
        public NewSurveyHandler(ISurveyRepository repository)
        {
            this.repository = repository;
        }

        public NewSurveyResource Get()
        {
            return new NewSurveyResource();
        }

        public OperationResult.SeeOther Post(NewSurveyResource resource)
        {
            var s = repository.Create(resource.Name, resource.Title, resource.Description);
            var r = new SurveyResource { Id = s.Id, Name = s.Name, Title = s.Title, Description = s.Description };
            return new OperationResult.SeeOther { RedirectLocation = r.CreateUri() };
        }
    }
}