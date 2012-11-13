using FluentAssertions;
using ScrumBoard.Domain;

using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class SprintSteps
    {
        private Sprint sprint;

        [Given(@"I have a sprint")]
        public void GivenIHaveASprint()
        {
            sprint = new Sprint();
            GenericSteps.StoreEntityForCurrentScenario(sprint);
        }

        [Then(@"It should have a stories collection")]
        public void ThenItShouldHaveAStoriesCollection()
        {
            sprint.Stories.Should().NotBeNull();
        }

        [Then(@"The commited effort is the sum of the efforts of each story in the sprint")]
        public void ThenTheCommitedEffortIsTheSumOfTheEffortsOfEachStoryInTheSprint()
        {
            sprint.Stories.Add(new UserStory { Effort = 0.5 });            
            sprint.Stories.Add(new UserStory { Effort = 2 });            
            sprint.Stories.Add(new UserStory { Effort = 2 });            
            sprint.Stories.Add(new UserStory { Effort = 4 });            
            sprint.Stories.Add(new UserStory { Effort = 5 });            

            sprint.CommittedEffort.Should().BeLessOrEqualTo(13.5);
        }
    }
}
