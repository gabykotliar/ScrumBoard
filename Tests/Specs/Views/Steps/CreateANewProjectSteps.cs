using System.Web.Mvc;

using FluentAssertions;

using ScrumBoard.Web.Controllers;
using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Views.Steps
{
    [Binding]
    public class CreateANewProjectSteps
    {
        private ProjectsController controller;
        private ActionResult actionResult;

        [When(@"the user navigates to the new project url")]
        public void WhenTheUserNavigatesToTheNewProjectUrl()
        {
            controller = new ProjectsController();
            actionResult = controller.New();
        }
        
        [Then(@"the new project view should be displayed")]
        public void ThenTheNewProjectViewShouldBeDisplayed()
        {
            actionResult.Should().BeOfType<ViewResult>();
        }
    }
}
