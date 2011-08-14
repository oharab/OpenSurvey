namespace OpenSurvey.Persistence.NHibernate.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenSurvey.Core.Repositories;
    using OpenSurvey.Core.Model;
    using Castle.Facilities.NHibernateIntegration;
    using global::NHibernate;
    using Castle.Services.Transaction;


    public class NHibernateSurveyRepository : ISurveyRepository
    {
        private readonly ISessionManager sessionManager;

        public NHibernateSurveyRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public IList<Survey> ListSurveys()
        {
            using (ISession session = sessionManager.OpenSession())
            {

                return session.CreateCriteria<Survey>()
                    .List<Survey>();
            }

        }

        public Survey GetSurvey(int id)
        {
            using (ISession session = sessionManager.OpenSession())
            {
                return session.Get<Survey>(id);
            }
        }


        public Survey Create(string name, string title, string description)
        {
            using (ISession session = sessionManager.OpenSession())
            using (var t=session.BeginTransaction())
            {
                var s = new Survey { Name = name, Title = title, Description = description };
                session.SaveOrUpdate(s);
                t.Commit();
                return s;
            }
        }

        public void Update(Survey survey)
        {
            using (ISession session = sessionManager.OpenSession())
            using(var t=session.BeginTransaction())
            {
                session.SaveOrUpdate(survey);
                t.Commit();
            }
        }
    }
}
