using System.Globalization;
using FluentAssertions;
using ScrumBoard.Domain;
using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class VelocitySteps
    {
        private Sprint sprint;

        [Given(@"A sprint with the following stories")]
        public void GivenASprintWithTheFollowingStories(Table table)
        {
            sprint = new Sprint();

            foreach (var row in table.Rows)
            {
                sprint.Stories.Add(new UserStory
                                       {
                                           Effort = double.Parse(row["Effort"], CultureInfo.GetCultureInfo("en").NumberFormat),
                                           IsDone = bool.Parse(row["IsDone"])
                                       });
            }
        }
        
        [Then(@"the Velocity should be (.*)")]
        public void ThenTheVelocityShouldBe(double expectedVelocity)
        {
            sprint.Velocity.Should().BeLessOrEqualTo(expectedVelocity)
                                .And.BeGreaterOrEqualTo(expectedVelocity);
        }
    }
}
