using System;
using FluentNHibernate.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumBoard.Domain;

namespace ScrumBoard.Tests.Persistence.Mappings
{
    [TestClass]
    public class RepositoryMappingsTest    
    {
        [ClassInitialize]
        public static void DeployDatabase(TestContext testContext)
        {
            var result = DeployDatabaseUtil.DeployTestDatabase();

            if (!result.ToLower().Contains("successfully"))
            {
                Assert.Fail("Database deployment failed with result: " + result);
            }
        }

        [TestMethod]
        public void ProjectMappingTest()
        {
            new PersistenceSpecification<Project>(SessionUtil.GetNewSession()).CheckProperty(x => x.Name, "Test Project")
                                                                              .CheckProperty(x => x.Vision, "Test Project Vision")
                                                                              .VerifyTheMappings();
        }

        [TestMethod]
        public void SprintMappingTest()
        {
            new PersistenceSpecification<Sprint>(SessionUtil.GetNewSession()).CheckProperty(x => x.StartsAt, new DateTime(2013, 1, 1))
                                                                             .CheckProperty(x => x.EndsAt, new DateTime(2013, 1, 2))
                                                                             .CheckReference(x => x.Project, new Project() { Name = "Test Project 2", Vision = "Test Project Vision 2" }, new EntityEqualityComparer<Project>())
                                                                             .VerifyTheMappings();
        }

        [TestMethod]
        public void TeamMappingTest()
        {
            new PersistenceSpecification<Team>(SessionUtil.GetNewSession()).VerifyTheMappings();
        }

        [TestMethod]
        public void UserStoryMappingTest()
        {
            new PersistenceSpecification<UserStory>(SessionUtil.GetNewSession()).CheckProperty(x => x.Text, "User Story Text")
                                                                                .CheckProperty(x => x.Effort, (double)1)
                                                                                .CheckProperty(x => x.IsDone, false)
                                                                                .CheckReference(x => x.Project, new Project() { Name = "Test Project 2", Vision = "Test Project Vision 2" }, new EntityEqualityComparer<Project>())
                                                                                .VerifyTheMappings();
        }

        [TestMethod]
        public void UserStoryWithSprintMappingTest()
        {
            var project = new Project() { Name = "Test Project 3", Vision = "Test Project Vision 3" };
            new PersistenceSpecification<UserStory>(SessionUtil.GetNewSession()).CheckProperty(x => x.Text, "User Story Text")
                                                                                .CheckProperty(x => x.Effort, (double)1)
                                                                                .CheckProperty(x => x.IsDone, false)
                                                                                .CheckReference(x => x.Project, project, new EntityEqualityComparer<Project>())
                                                                                .CheckReference(x => x.Sprint, new Sprint() { Project = project, StartsAt = new DateTime(2013, 1, 1), EndsAt = new DateTime(2013, 1, 2) }, new EntityEqualityComparer<Sprint>())                                                                                
                                                                                .VerifyTheMappings();
        }
    }
}
