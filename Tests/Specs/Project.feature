Feature: Project
	In order to manage a project with Scrum
	As a team member
	I want to manage the standard artifacts

Scenario: I should be hable to uniquely identify a project
	Given I have a project	
	Then It should have a unique key

Scenario: A project should have a name
	Given I have a project	
	Then I should be hable to assign a name to it

Scenario: A project should have a backlog
	Given I have a project	
	Then It should have a backlog
