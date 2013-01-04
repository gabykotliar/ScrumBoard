using System;
using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class SearchByKeySteps
    {
        [Given(@"a project named '(.*)'")]
        public void GivenAProjectNamed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the key should be '(.*)'")]
        public void ThenTheKeyShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
