using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPlayer : ComputerPlayer
{
    private Task behaviorTree;
    private TaskStatus behaviorTreeStatus = TaskStatus.None;
    private Vector2Int nextPos;

    public void Update()
    {
        base.Update();
    }

    public override void OnGameStarted()
    {
        base.OnGameStarted();
        Sequence sequence = new Sequence();
        TimeCondition time = new TimeCondition();
        GetClosestSpeedAction action = new GetClosestSpeedAction();
        behaviorTree = sequence;

        sequence.AddChildren(time);
        sequence.AddChildren(action);
        nextPos = this.CurrentTile;
        // Did you know that Mango is a tree?
    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        behaviorTreeStatus = behaviorTree.Run(this, null);
    }


}
