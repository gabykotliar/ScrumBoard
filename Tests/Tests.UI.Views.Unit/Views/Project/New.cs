using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RazorGenerator.Testing;
using ScrumBoard.Domain;
using Tests.UI.Views.Views.Home;
using Tests.UI.Views.Views.Projects;

namespace Tests.UI.Views.Unit
{
    [TestClass]
    public class NewProjectTests
    {
        [TestMethod]
        public void When_trying_to_create_new_project_ensure_all_elements_show()
        {
            // Instantiate the view directly. This is made possible by
            // the fact that we precompiled it
            var newProjectView = new New();

            // Create the model to be sent to the view if needed
            //var model = new Model();

            // Set up the data that needs to be accessed by the view
            //newProjectView.ViewBag.Title = "Testing";

            // Render it in an HtmlAgilityPack HtmlDocument. Note that
            // you can pass a 'model' object here if your view needs one.
            // Generally, what you do here is similar to how a controller
            //action sets up data for its view.
            var doc = newProjectView.RenderAsHtml();

            // Use the HtmlAgilityPack object model to verify the view.
            // Here, we simply check that the first <h2> tag contains
            // what we put in view.ViewBag.Message
            
            //var nameTextbox = doc.

            var nameTextbox = doc.GetElementbyId("name");
            var visionTextbox = doc.GetElementbyId("vision");
            var codeTextbox = doc.GetElementbyId("code");
            var submitBtn = doc.GetElementbyId("submit");

            Assert.IsNotNull(nameTextbox);
            Assert.IsNotNull(visionTextbox);
            Assert.IsNotNull(codeTextbox);
            Assert.IsNotNull(submitBtn);

            //Assert.AreEqual("Testing", node.InnerHtml.Trim());
        }
    }
}
