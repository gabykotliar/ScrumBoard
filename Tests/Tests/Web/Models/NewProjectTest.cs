using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScrumBoard.Web.Models;

namespace ScrumBoard.Tests.Web.Models
{
    [TestClass]
    public class NewProjectTest
    {
        [TestMethod]        
        public void ToEntityTest()
        {
            var nameValue = "name value";
            var visionValue = "vision value";

            var project = new NewProject
                {
                    Name = nameValue,
                    Vision = visionValue,
                }.ToEntity();

            project.Name.Should().Be(nameValue);
            project.Vision.Should().Be(visionValue);            
        }
    }
}
