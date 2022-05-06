using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjangoPlayer : ComputerPlayer
{
    public override void OnGameStarted()
    {
        base.OnGameStarted();

        // This will be the real Django Unchained!
    }


    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        if (pathTilesQueue.Count == 0)
        {
            for (var i = 0; i < players.Count; ++i)
            {
                if (players[i] != this)
                {
                    if (Vector2Int.Distance(CurrentTile, players[i].CurrentTile) <= 1.0f)
                    {
                        pathTilesQueue.Enqueue(players[i].CurrentTile);
                        break;
                    }
                }
            }
        }
    }
}
