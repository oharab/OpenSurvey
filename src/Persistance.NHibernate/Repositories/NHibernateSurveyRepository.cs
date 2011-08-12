﻿namespace OpenSurvey.Persistence.NHibernate.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OpenSurvey.Core.Repositories;
    using OpenSurvey.Core.Model;
    using Castle.Facilities.NHibernateIntegration;
    using global::NHibernate;
    

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


        public void SaveSurvey(Survey s)
        {
            using (ISession session = sessionManager.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(s);
                    session.Transaction.Commit();
                }
            }
        }
    }
}
