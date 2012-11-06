using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using ScrumBoard.Services;
using ScrumBoard.Web.Controllers.Api;

namespace ScrumBoard.Tests.Web.Api
{
    [TestClass]
    public class ProjectControllerTest
    {
        [TestMethod]
        [Description("It should be possible to inject dependencies through the constructor")]
        public void ConstructorTest()
        {
            var controller = new ProjectController(new Mock<ProjectService>().Object);

            controller.Should().NotBeNull();
        }
    }
}
