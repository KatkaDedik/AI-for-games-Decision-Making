using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangoPlayer : ComputerPlayer
{
    private Task behaviorTree;
    

    public override void OnGameStarted()
    {
        base.OnGameStarted();

        Sequence sequence = new Sequence();

        FindBestChanceCollectibleAction find = new FindBestChanceCollectibleAction();
        sequence.AddChildren(find);
        WaitUntilCollectedAction wait = new WaitUntilCollectedAction();
        sequence.AddChildren(wait);

        behaviorTree = sequence;

        // Wikipedia says:
        // Tango is a partner dance and social dance that originated in the 1880s
        // along the Río de la Plata, the natural border between Argentina and Uruguay.
        // ---
        // Is this relevant? Probably not but it is nice to learn something, right?
    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        if (behaviorTree.Run(this, null) == TaskStatus.Succes)
        {
            behaviorTree.SetStatus(TaskStatus.None);
        }
    }
}
