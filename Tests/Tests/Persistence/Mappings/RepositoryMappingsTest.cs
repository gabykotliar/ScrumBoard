using System;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;
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

            BuilderSetup.DisablePropertyNamingFor<Project, int>(o => o.Id);
            BuilderSetup.DisablePropertyNamingFor<Sprint, int>(o => o.Id);
            BuilderSetup.DisablePropertyNamingFor<Team, int>(o => o.Id);
            BuilderSetup.DisablePropertyNamingFor<UserStory, int>(o => o.Id);
        }         

        [TestMethod]
        public void ProjectMappingTest()
        {
            new PersistenceSpecification<Project>(SessionUtil.GetNewSession()).CheckProperty(x => x.Name, GetRandom.String(255))
                                                                              .CheckProperty(x => x.Code, GetRandom.String(255))
                                                                              .CheckProperty(x => x.Vision, GetRandom.String(2000))
                                                                              .VerifyTheMappings();
        }

        [TestMethod]
        public void SprintMappingTest()
        {            
            new PersistenceSpecification<Sprint>(SessionUtil.GetNewSession()).CheckProperty(x => x.StartsAt, GetRandom.DateTime(), new MappingEqualityComparer<DateTime>())
                                                                             .CheckProperty(x => x.EndsAt, GetRandom.DateTime(), new MappingEqualityComparer<DateTime>())
                                                                             .CheckReference(x => x.Project, Builder<Project>.CreateNew().Build(), new MappingEqualityComparer<Project>())
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
            new PersistenceSpecification<UserStory>(SessionUtil.GetNewSession()).CheckProperty(x => x.Text, GetRandom.String(2000))
                                                                                .CheckProperty(x => x.Effort, GetRandom.Double())
                                                                                .CheckProperty(x => x.IsDone, GetRandom.Boolean())
                                                                                .CheckReference(x => x.Project, Builder<Project>.CreateNew().Build(), new MappingEqualityComparer<Project>())
                                                                                .VerifyTheMappings();
        }

        [TestMethod]
        public void UserStoryWithSprintMappingTest()
        {
            var project = Builder<Project>.CreateNew().Build();
            var sprint = Builder<Sprint>.CreateNew().Do(s => s.Project = project).Build();
            new PersistenceSpecification<UserStory>(SessionUtil.GetNewSession()).CheckProperty(x => x.Text, GetRandom.String(2000))
                                                                                .CheckProperty(x => x.Effort, GetRandom.Double())
                                                                                .CheckProperty(x => x.IsDone, GetRandom.Boolean())
                                                                                .CheckReference(x => x.Project, project, new MappingEqualityComparer<Project>())
                                                                                .CheckReference(x => x.Sprint, sprint, new MappingEqualityComparer<Sprint>())                                                                                
                                                                                .VerifyTheMappings();
        }
    }
}
