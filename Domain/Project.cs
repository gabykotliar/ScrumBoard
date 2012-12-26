using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScrumBoard.Domain
{
    public class Project 
    {        
        public Project()
        {
            Backlog = new ProductBacklog();
            Sprints = new List<Sprint>();
            Team = new Team();
        }
        
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Vision { get; set; }

        public virtual IList<UserStory> Backlog { get; protected set; }

        public virtual IList<Sprint> Sprints { get; protected set; }

        public virtual Team Team { get; protected set; }
    }
}
