namespace OpenSurvey.Web.Handlers
{
    using System;
using OpenSurvey.Web.Resources;

    public class HomeHandler
    {
        public HomeResource Get()
        {
            return new HomeResource();
        }
    }
}