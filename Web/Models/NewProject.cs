using System.ComponentModel.DataAnnotations;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Models
{
    public class NewProject
    {
        [Required]
        public string Name { get; set; }

        public string Vision { get; set; }

        public virtual Project ToEntity()
        {
            return new Project
                {
                    Name = Name,
                    Vision = Vision
                };
        }
    }
}