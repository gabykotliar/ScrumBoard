using FluentNHibernate.Mapping;
using ScrumBoard.Domain;

namespace ScrumBoard.Persistence.Implementation.Mappings
{
    public class SprintMapping : ClassMap<Sprint>
    {
        public SprintMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.StartsAt);
            Map(x => x.EndsAt);
            HasMany(x => x.Stories).KeyColumn("SprintId");
        }
    }
}
