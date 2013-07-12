using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public ICollection<ValidationResult> Create(Project project)
        {
            var vr = new Collection<ValidationResult>();

            if (repository.Find(p => p.Code == project.Code).Any())
            {
                vr.Add(new ValidationResult("The code must be unique.", new[] { "Code" }));

                return vr;
            }

            repository.SaveOrUpdate(project);            

            return vr;
        }

        public Project GetByCode(string code)
        {
            return repository.Get(p => p.Code == code);
        }
    }
}
