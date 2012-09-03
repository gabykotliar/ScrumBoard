Feature: Sprint
	In order to plan and organize my work
	As a team member
	I want to be able divide the project in sprints

Scenario: A sprint should have a start and an end date
	Given I have a sprint
	Then I should be able to assign a 'StartsAt' as a date
	And I should be able to assign a 'EndsAt' as a date

Scenario: The team should be able to compromise stories for a sprint
	Given I have a sprint
	Then It should have a stories collection

Scenario: A sprint have a commited effort
	Given I have a sprint
	Then The commited effort is the sum of the efforts of each story in the sprint

Scenario: A sprint has a velocity
	Given I have a sprint
	Then 