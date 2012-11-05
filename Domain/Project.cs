﻿using System.Collections.Generic;
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

        public virtual ProductBacklog Backlog { get; private set; }

        public virtual IList<Sprint> Sprints { get; private set; }

        public virtual Team Team { get; protected set; }
    }
}
