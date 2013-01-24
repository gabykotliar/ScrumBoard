using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ScrumBoard.Domain;

namespace ScrumBoard.Services
{
    public interface ProjectService
    {
        Project GetByCode(string code);

        bool TryCreate(Project project, out ICollection<ValidationResult> validationErrors);        
    }
}
