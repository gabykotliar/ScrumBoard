using ScrumBoard.Domain;

namespace ScrumBoard.Services.Implementation
{
    public class ProjectService : Services.ProjectService
    {
        public void Create(Project project)
        {
            project.Id = 1;
        }
    }
}
