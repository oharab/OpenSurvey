namespace OpenSurvey.Persistence.NHibernate.Mappings
{
    using System;
    using FluentNHibernate.Mapping;
    using OpenSurvey.Core.Model;

    public class QuestionMap:ClassMap<Question>
    {
        public QuestionMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Native();
            Map(x => x.QuestionText)
                .Not.Nullable();

        }
    }
}
