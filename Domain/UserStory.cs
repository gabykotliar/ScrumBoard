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
    }
}
