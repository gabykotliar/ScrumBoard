namespace ScrumBoard.Domain
{
    public class Project 
    {
        public Project()
        {
            Backlog = new ProductBacklog();
        }
        
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ProductBacklog Backlog { get; set; }
    }
}
