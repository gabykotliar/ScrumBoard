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

        public bool TryCreate(Project project, out ICollection<ValidationResult> validationErrors)
        {
            validationErrors = Validate(project);

            if (validationErrors.Any()) return false;

            repository.SaveOrUpdate(project);

            return true;
        }

        private ICollection<ValidationResult> Validate(Project project)
        {
            var validationErrors = new Collection<ValidationResult>();

            var context = new ValidationContext(project, serviceProvider: null, items: null);
            Validator.TryValidateObject(project, context, validationErrors, true);

            if (CodeIsAlreadyInUse(project.Code))
            {
                validationErrors.Add(new ValidationResult("The code is not available.", new[] { "Code" }));
            }

            return validationErrors;
        }

        private bool CodeIsAlreadyInUse(string code)
        {
            return repository.Get(p => p.Code == code) != null;
        }

        public Project GetByCode(string code)
        {
            return repository.Get(p => p.Code == code);
        }
    }
}
