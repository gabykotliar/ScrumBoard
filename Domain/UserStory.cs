namespace ScrumBoard.Domain
{
    public class UserStory
    {
        public UserStory()
        {
            Text = "As a <role>, I want <goal/desire> so that <benefit>";
        }

        public virtual int Id { get; set; }

        public virtual string Text { get; set; }

        public virtual double Effort { get; set; }

        public virtual bool IsDone { get; set; }

        public virtual Sprint Sprint { get; set; }

        public virtual Project Project { get; set; }
    }
}
