﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FluentAssertions;
using ScrumBoard.Domain;
using TechTalk.SpecFlow;

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

        [Given(@"The project name is '(.*)'")]
        public void GivenTheProjectNameIs(string name)
        {
            project.Name = name;
        }

        [Then(@"The project is invalid")]
        public void ThenTheProjectIsInvalid()
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(project, null, null);

            Validator.TryValidateObject(project, context, results).Should().BeFalse();
        }
    }
}
