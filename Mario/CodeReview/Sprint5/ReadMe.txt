Per discussion with the grader, our group is addressing some substantial refactoring concerns and deferring some feature correctness 
until the Sprint's final implementation deadline.

Completed Objectives:
1. Underground Level (go down first pipe, come up second pipe)
2. Pausing
In-Progress Objectives:
1. HUD
	- system for displaying text on screen ("Mario")
2. Points and score system
	- containers exist for this info inside of mario, but there is no mechanism to change them yet
3. Removing magic numbers. Most are absent (except for some zero initializers)

Not-Completed Objectives:
1. Sounds
2. Floating Coins (In Underground)
3. Remaining Lives Screen

Problems causing holds:
1. Issues with refactored collision handlers. 
Several new features extend collision features, so the new system should be in place to avoid acruing more debt

