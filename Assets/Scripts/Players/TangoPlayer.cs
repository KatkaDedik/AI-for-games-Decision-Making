using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangoPlayer : ComputerPlayer
{
    public override void OnGameStarted()
    {
        base.OnGameStarted();

        // Wikipedia says:
        // Tango is a partner dance and social dance that originated in the 1880s
        // along the Río de la Plata, the natural border between Argentina and Uruguay.
        // ---
        // Is this relevant? Probably not but it is nice to learn something, right?
    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        Vector2Int[] neighbouringTiles =
        {
            new Vector2Int(CurrentTile.x + 1, CurrentTile.y),
            new Vector2Int(CurrentTile.x, CurrentTile.y - 1),
            new Vector2Int(CurrentTile.x - 1, CurrentTile.y),
            new Vector2Int(CurrentTile.x, CurrentTile.y + 1)
        };

        if (pathTilesQueue.Count == 0)
        {
            for (var i = 0; i < neighbouringTiles.Length; ++i)
            {
                if (maze.IsValidTileOfType(neighbouringTiles[i % neighbouringTiles.Length], MazeTileType.Free))
                {
                    pathTilesQueue.Enqueue(neighbouringTiles[i % neighbouringTiles.Length]);
                    break;
                }
            }
        }
    }
}
