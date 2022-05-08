using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjangoPlayer : ComputerPlayer
{

    private Task behaviorTree;

    public override void OnGameStarted()
    {
        base.OnGameStarted();

        Sequence RootSequence = new Sequence();
        Selector selector = new Selector();

        FindClosestAction collectPoints = new FindClosestAction(CollectibleItemType.AddPoint);
        FindClosestAction collectSpeed = new FindClosestAction(CollectibleItemType.IncreaseMovementSpeed);
        FindClosestAction collectReset = new FindClosestAction(CollectibleItemType.RespawnAll);

        WaitUntilCollectedAction wait = new WaitUntilCollectedAction();

        

        RootSequence.AddChildren(selector);
        RootSequence.AddChildren(wait);

        selector.AddChildren(collectPoints);
        selector.AddChildren(collectSpeed);
        selector.AddChildren(collectReset);

        behaviorTree = RootSequence;

        // This will be the real Django Unchained!
    }


    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        behaviorTree.Run(this, null);
        behaviorTree.SetStatus(TaskStatus.None);
    }
}
