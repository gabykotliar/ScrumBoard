﻿using System.Collections.Generic;
using FluentValidation;

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

        public virtual string Name { get; set; }

        public virtual string Vision { get; set; }

        public virtual ProductBacklog Backlog { get; set; }

        public virtual IList<Sprint> Sprints { get; set; }

        public virtual Team Team { get; set; }
    }

    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty();            
        }
    }
}
