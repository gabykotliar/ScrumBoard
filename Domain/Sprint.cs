using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrumBoard.Domain
{
    public class Sprint 
    {
        public Sprint()
        {
            Stories = new List<UserStory>();
        }

        public virtual DateTime StartsAt { get; set; }

        public virtual DateTime EndsAt { get; set; }

        public  virtual List<UserStory> Stories { get; set; }

        public virtual double CommitedEffort
        {
            get { return Stories.Sum(s => s.Effort); }
        }

        public virtual double Velocity
        {
            get { return Stories.Where(s => s.IsDone).Sum(s => s.Effort); }
        }
    }
}