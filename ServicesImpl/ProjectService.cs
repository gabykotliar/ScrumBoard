using ScrumBoard.Domain;

namespace ScrumBoard.Services.Implementation
{
    using ScrumBoard.Persistence;

    public class ProjectService : Services.ProjectService
    {
        private readonly ProjectRepository repository;

        public ProjectService(ProjectRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Project project)
        {
            this.repository.SaveOrUpdate(project);            
        }
    }
}
