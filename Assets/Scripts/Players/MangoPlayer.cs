using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPlayer : ComputerPlayer
{
    public override void OnGameStarted()
    {
        base.OnGameStarted();

        // Did you know that Mango is a tree?
    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        if (pathTilesQueue.Count == 0)
        {
            for (var i = 0; i < spawnedCollectibles.Count; ++i)
            {
                if (Vector2Int.Distance(CurrentTile, spawnedCollectibles[i].TileLocation) <= 1.0f)
                {
                    pathTilesQueue.Enqueue(spawnedCollectibles[i].TileLocation);
                    break;
                }
            }
        }
    }
}
