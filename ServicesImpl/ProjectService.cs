using ScrumBoard.Domain;
using ScrumBoard.Persistence;

namespace ScrumBoard.Services.Implementation
{
    public class ProjectService : Services.ProjectService
    {
        private readonly ProjectRepository repository;

        public ProjectService(ProjectRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Project project)
        {
            repository.SaveOrUpdate(project);            
        }

        public Project GetByCode(string code)
        {
            return repository.Get(p => p.Code == code);
        }
    }
}
