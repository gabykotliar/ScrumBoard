using System.ComponentModel.DataAnnotations;

using ScrumBoard.Domain;

namespace ScrumBoard.Web.Models
{
    public class NewProject
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Vision { get; set; }

        public Project ToEntity()
        {
            return new Project
                {
                    Code = Code,
                    Name = Name,
                    Vision = Vision
                };
        }
    }
}