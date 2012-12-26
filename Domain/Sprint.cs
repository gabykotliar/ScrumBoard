using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ScrumBoard.Domain
{
    public class Sprint 
    {
        public Sprint()
        {
            Stories = new Collection<UserStory>();
        }

        public virtual int Id { get; set; }

        public virtual DateTime StartsAt { get; set; }

        public virtual DateTime EndsAt { get; set; }

        public virtual Collection<UserStory> Stories { get; protected set; }

        public virtual double CommittedEffort
        {
            get { return Stories.Sum(s => s.Effort); }
        }

        public virtual double Velocity
        {
            get { return Stories.Where(s => s.IsDone).Sum(s => s.Effort); }
        }
    }
}