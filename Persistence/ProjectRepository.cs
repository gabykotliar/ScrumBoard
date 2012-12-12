using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Persistence
{
    using Common.Persistence;

    using ScrumBoard.Domain;

    public interface ProjectRepository : Repository<Project>
    {
    }
}
