using System.Web.Mvc;
using ScrumBoard.Domain;
using ScrumBoard.Web.Controllers;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace ScrumBoard.Specs.Views.Steps
{
    [Binding]
    public class CreateANewProjectSteps
    {
        private ProjectController controller;
        private ActionResult actionResult;

        [When(@"the user navigates to the new project url")]
        public void WhenTheUserNavigatesToTheNewProjectUrl()
        {
            controller = new ProjectController();
            actionResult = controller.New();
        }
        
        [Then(@"the new project view should be displayed")]
        public void ThenTheNewProjectViewShouldBeDisplayed()
        {
            actionResult.Should().BeOfType<ViewResult>();
        }
    }
}
