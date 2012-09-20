Feature: Velocity
	In order to measure the productivity of the team
	I want to be able to measure the Velocity of the team
	That is defined as the sum of the commited effort for the completed stories in a sprint

Scenario: An empty sprint has a velocity of 0
	Given A sprint with the following stories
		| Effort | IsDone |
	Then the Velocity should be 0 

Scenario: An sprint with all stories undone has a velocity of 0
	Given A sprint with the following stories
		| Effort | IsDone |
		| 1		 | false  |
		| 2		 | false  |
		| 5		 | false  |
	Then the Velocity should be 0 

Scenario: An sprint with done and undone stories 
	Given A sprint with the following stories
		| Effort | IsDone |
		| 1		 | false  |
		| 2		 | true   |
		| 5		 | true   |
		| 4		 | false  |
		| 0.5	 | true   |
	Then the Velocity should be 7.5 

Scenario: An sprint with all stories done 
	Given A sprint with the following stories
		| Effort | IsDone |
		| 1		 | true   |
		| 2		 | true   |
		| 5		 | true   |
		| 4		 | true   |
		| 0.5	 | true   |
	Then the Velocity should be 12.5 