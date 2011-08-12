namespace OpenSurvey.Web.Resources
{
    using System;
    using OpenSurvey.Core.Repositories;
    using System.Collections.Generic;

    public class HomeResource
    {
        private readonly ISurveyRepository repository;
        public HomeResource(ISurveyRepository repository)
        {
            this.repository = repository;
        }

        public IList<SurveyResource> Surveys
        {
            get {
                var l = new List<SurveyResource>();
                foreach (var s in repository.ListSurveys())
                {
                    l.Add(new SurveyResource{Id=s.Id,
                                            Name=s.Name,
                                            Title=s.Title,
                                            Description=s.Description});
                }

                return l;
            }
        }
        

    }
}