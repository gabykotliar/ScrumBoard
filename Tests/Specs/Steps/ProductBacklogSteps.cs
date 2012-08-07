using ScrumBoard.Domain;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class ProductBacklogSteps
    {
        private ProductBacklog backlog;

        [Given(@"I have a Product Backlog")]
        public void GivenIHaveAProductBacklog()
        {
            backlog = new ProductBacklog();
        }
        
        [Then(@"I should be able to add a User Story")]
        public void ThenIShouldBeAbleToAddAUserStory()
        {
            var target = new UserStory();

            backlog.Add(target);

            backlog.Should().Contain(target);
        }
    }
}
