namespace OpenSurvey.Web.Resources
{
    using System;
using System.Collections.Generic;

    public class SurveyResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public IList<string> Questions { get; set; }
    }
}