using FluentNHibernate.Mapping;
using ScrumBoard.Domain;

namespace ScrumBoard.Persistence.Implementation.Mappings
{
    public class UserStoryMapping : ClassMap<UserStory>
    {
        public UserStoryMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Effort);
            Map(x => x.IsDone);
            Map(x => x.Text);
            References(x => x.Sprint).Column("SprintId").Nullable();
            References(x => x.Project).Column("ProjectId");
        }
    }
}
