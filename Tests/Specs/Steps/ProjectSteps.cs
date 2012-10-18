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
        
        [Then(@"It should have a backlog")]
        public void ThenItShouldHaveABacklog()
        {
            project.Backlog.Should().NotBeNull();
        }

        [Then(@"It should have a sprint collection")]
        public void ThenItShouldHaveASprintCollection()
        {
            project.Sprints.Should().NotBeNull();
        }

        [Then(@"It should have a team")]
        public void ThenItShouldHaveATeam()
        {
            project.Team.Should().NotBeNull();
        }

        [Given(@"A project with name '(.*)'")]
        public void GivenAProjectWithName(string projectName)
        {
            project.Name = projectName;
        }

        [Then(@"The project is invalid")]
        public void ThenTheProjectIsInvalid()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
