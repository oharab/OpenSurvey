namespace OpenSurvey.Core.Repositories
{
    using System;
using OpenSurvey.Core.Model;
using System.Collections.Generic;

    public interface ISurveyRepository
    {
        Survey GetSurvey(int Id);
        IList<Survey> ListSurveys();
    }
}
