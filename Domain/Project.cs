using System.Collections.Generic;

namespace ScrumBoard.Domain
{
    public class Project 
    {        
        public Project()
        {
            Backlog = new ProductBacklog();
            Sprints = new List<Sprint>();
        }
        
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ProductBacklog Backlog { get; set; }

        public List<Sprint> Sprints { get; set; }
    }
}
