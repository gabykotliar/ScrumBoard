using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ScrumBoard.Domain;

namespace ScrumBoard.Services
{
    public interface ProjectService
    {
        ICollection<ValidationResult> Create(Project project);

        Project GetByCode(string code);
    }
}
