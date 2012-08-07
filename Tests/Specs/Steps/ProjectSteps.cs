using ScrumBoard.Domain;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class ProjectSteps
    {
        private Project project; 

        [Given(@"I have a project")]
        public void GivenIHaveAProject()
        {
            project = new Project();
            GenericSteps.StoreEntityForCurrentScenario(project);
        }
        
        [Then(@"I should be hable to assign a name to it")]
        public void ThenIShouldBeHableToAssignANameToIt()
        {
            const string expected = "someName";
            project.Name = expected;
            project.Name.Should().Be(expected);
        }

        [Then(@"It should have a backlog")]
        public void ThenItShouldHaveABacklog()
        {
            project.Backlog.Should().NotBeNull();
        }
    }
}
