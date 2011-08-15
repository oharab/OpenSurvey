namespace OpenSurvey.Core.Model
{
    using System;

    public class Survey
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
