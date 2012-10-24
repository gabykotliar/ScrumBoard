using System.Collections.Generic;
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
            sprint.Stories = new List<UserStory>
                                 {
                                     new UserStory { Effort = 0.5 },
                                     new UserStory { Effort = 2 },
                                     new UserStory { Effort = 2 },
                                     new UserStory { Effort = 4 },
                                     new UserStory { Effort = 5 },
                                 };

            sprint.CommitedEffort.Should().BeLessOrEqualTo(13.5);
        }
    }
}
