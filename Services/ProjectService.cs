using ScrumBoard.Domain;

namespace ScrumBoard.Services
{
    public interface ProjectService
    {
        void Create(Project project);

        Project GetByCode(string code);
    }
}
