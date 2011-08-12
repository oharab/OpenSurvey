namespace OpenSurvey.Web.Handlers
{
    using System;
using OpenSurvey.Web.Resources;

    public class HomeHandler
    {
        HomeResource home;
        public HomeHandler(HomeResource home)
        {
            this.home = home;
        }

        public HomeResource Get()
        {
            return home;
        }
    }
}