using Common.Persistence.NHibernate;
using NHibernate;
using ScrumBoard.Domain;

namespace ScrumBoard.Persistence.Implementation
{
    public class ProjectRepository : RepositoryBase<Project>, Persistence.ProjectRepository
    {
        public ProjectRepository(ISession session)
            : base(session)
        {
        }
    }
}
