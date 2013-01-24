using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ScrumBoard.Domain
{
    public class Project
    {        
        public Project()
        {
            Backlog = new ProductBacklog();
            Sprints = new Collection<Sprint>();
            Team = new Team();
        }
        
        public virtual int Id { get; set; }

        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Vision { get; set; }

        public virtual ICollection<UserStory> Backlog { get; protected set; }

        public virtual ICollection<Sprint> Sprints { get; protected set; }

        public virtual Team Team { get; protected set; }
    }
}
