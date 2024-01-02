# AI for games hw3 - Decision Making




Task 1: Navigation:

● Implement an appropriate pathfinding algorithm allowing for movement in 8 directions (you
can reuse your solution from Assignment 2 – the constraints defined in that assignment still
apply). The algorithm must be able to find the shortest path between two points.
● Use this algorithm in the ComputerPlayer.GetPathFromTo function.
● This assignment will include multiple agents walking around the maze. This may result in the
agents colliding into each other or in any other way occupying the same maze field. This
behavior is allowed for this task. Therefore, in other words, you can ignore other agents
during the path computation procedure.


Task 2: Behavior Tree:

● Implement a behavior tree system offering at least standard leaf (action, condition) and
interior (selector, sequence) nodes.
● Additionally, some decorator node like inverter or repeater should be implemented as well.
● The implementation should also contain a simple blackboard system for data storage.
● Implementation note: Feel free to create a new folder for your BT implementations in the
Scripts.


Task 3: Implement behavior of individual agents

● By default, the game contains four agents. One of them is controlled by a human player. The
remaining three agents are to be programmed by you.
● Each agent is expected to be controlled by the BT using your implementation of the BT
system from the previous task. For each agent, the BT should be created once and then
evaluated, thus not recreated every frame.
● Each of the three agents must exhibit different behavior. In other words, their decisions must
not be controlled by the exact same behavior trees but by different ones. They can have
different nodes, their order, different parameters and so on.
● For each agent, the tree must be manually assembled in the code / Unity – in other words,
some intentionally non-deterministic behavior of a tree node will not be a sufficient solution
for the “tree difference”.
● Also, each agent must take into consideration all important aspects of the game.
