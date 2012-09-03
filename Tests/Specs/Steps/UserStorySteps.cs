using FluentAssertions;
using ScrumBoard.Domain;
using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class UserStorySteps
    {
        private UserStory story;

        [Given(@"I have a story")]
        public void GivenIHaveAStory()
        {
            story = new UserStory();
            GenericSteps.StoreEntityForCurrentScenario(story);
        }
        
        [When(@"I create a new story")]
        public void WhenICreateANewStory()
        {
            story = new UserStory();
        }
        
        [Then(@"I should be able to define its text")]
        public void ThenIShouldBeAbleToDefineItsText()
        {
            const string expected = "some text";

            story.Text = expected;

            story.Text.Should().Be(expected);
        }
        
        [Then(@"the story should follow this template '(.*)'")]
        public void ThenTheStoryShouldFollowThisTemplate(string defaultValue)
        {
            story.Text.Should().Be(defaultValue);
        }

        [When(@"It is DONE")]
        public void WhenItIsDone()
        {
            story.IsDone = true;
        }

        [Then(@"The story is completed")]
        public void ThenTheStoryIsCompleted()
        {
            story.IsDone.Should().BeTrue();
        }

    }
}
