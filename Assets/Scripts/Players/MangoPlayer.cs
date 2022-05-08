using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPlayer : ComputerPlayer
{
    private Task behaviorTree;
    public Vector2Int[] currentPath;
    public override void OnGameStarted()
    {
        base.OnGameStarted();

        Sequence RootSequence = new Sequence();
        RepeaterUntilFailDecorator repeater = new RepeaterUntilFailDecorator();
        Selector selector = new Selector();

        Sequence sequence = new Sequence();
        
        TimeCondition time = new TimeCondition(45f);
        Selector TimeSelector = new Selector();

        FindClosestAction collectSpeed = new FindClosestAction(CollectibleItemType.IncreaseMovementSpeed);
        FindClosestAction collectReset = new FindClosestAction(CollectibleItemType.RespawnAll);
        DoNothingAction nothingAction = new DoNothingAction();

        WaitUntilCollectedAction wait = new WaitUntilCollectedAction();

        FindClosestAction collectPoints = new FindClosestAction(CollectibleItemType.AddPoint);

        RootSequence.AddChildren(repeater);
        RootSequence.AddChildren(selector);
        RootSequence.AddChildren(wait);

        selector.AddChildren(collectPoints);
        selector.AddChildren(collectReset);
        selector.AddChildren(collectSpeed);

        repeater.AddChildren(sequence);

        sequence.AddChildren(time);
        sequence.AddChildren(TimeSelector);

        sequence.AddChildren(wait);

        TimeSelector.AddChildren(collectSpeed);
        TimeSelector.AddChildren(collectReset);
        TimeSelector.AddChildren(collectPoints);
        TimeSelector.AddChildren(nothingAction);

        behaviorTree = RootSequence;

        
        // Did you know that Mango is a tree?
    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        behaviorTree.Run(this, null);
        behaviorTree.SetStatus(TaskStatus.None);
        currentPath = pathTilesQueue.ToArray();
    }


}
