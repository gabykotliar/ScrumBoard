Feature: Sprint
	In order to plan and organize my work
	As a team member
	I want to be able divide the project in sprints

Scenario: A sprint should have a start and an end date
	Given I have a sprint
	Then I should be able to assign an 'StartsAt' as date
	And I should be able to assign an 'EndsAt' as date
