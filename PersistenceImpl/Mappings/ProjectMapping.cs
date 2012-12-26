using FluentNHibernate.Mapping;
using ScrumBoard.Domain;

namespace ScrumBoard.Persistence.Implementation.Mappings
{
    public class ProjectMapping : ClassMap<Project>
    {
        public ProjectMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Vision);
            HasMany(x => x.Backlog).KeyColumn("ProjectId");
            HasMany(x => x.Sprints).KeyColumn("ProjectId");
            HasOne(x => x.Team);
        }
    }
}
