Feature: Project
	In order to manage a project with Scrum
	As a team member
	I want to manage the standard artifacts

Scenario: I should be able to uniquely identify a project
	Given I have a project	
	Then It should have a unique key

Scenario: A project should have a name
	Given I have a project	
	Then I should be able to assign a 'Name' as a text

Scenario: A project should have a vision
	Given I have a project
	Then I should be able to assign a 'Vision' as a text

Scenario: A project should have a backlog
	Given I have a project	
	Then It should have a backlog

Scenario: A project should have sprints
	Given I have a project
	Then It should have a sprint collection

Scenario: A project have a team that works on it
	Given I have a project
	Then It should have a team