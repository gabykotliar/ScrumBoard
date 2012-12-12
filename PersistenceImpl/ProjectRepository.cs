using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Persistence.Implementation
{
    using System.Linq.Expressions;

    using Common.Persistence.NHibernate;

    using NHibernate;

    using ScrumBoard.Domain;

    public class ProjectRepository : RepositoryBase<Project>, Persistence.ProjectRepository
    {
        public ProjectRepository(ISession session)
            : base(session)
        {
        }
    }
}
