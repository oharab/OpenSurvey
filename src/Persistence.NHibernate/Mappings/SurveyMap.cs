namespace OpenSurvey.Persistence.NHibernate.Mappings
{
    using System;
    using FluentNHibernate.Mapping;
    using OpenSurvey.Core.Model;

    public class SurveyMap:ClassMap<Survey>
    {
        public SurveyMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Native();
            Map(x => x.Name)
                .Unique()
                .Index("idxSurvey")
                .Not.Nullable();
            Map(x => x.Title)
                .Not.Nullable();
            Map(x => x.Description)
                .Not.Nullable();
            HasMany<Question>(x=>x.Questions);
        }
    }
}
