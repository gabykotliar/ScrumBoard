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

        [Then(@"'(.*)' should be always after '(.*)'")]
        public void ThenYShouldBeAlwaysAfterX(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
