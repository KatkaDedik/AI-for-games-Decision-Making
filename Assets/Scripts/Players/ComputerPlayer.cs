using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
public abstract class ComputerPlayer : AbstractPlayer
{
    public Queue<Vector2Int> pathTilesQueue = new Queue<Vector2Int>();
    public CollectibleItem currentTarget;

    public override void OnGameStarted()
    {
        base.OnGameStarted();
    }

    protected override void Update()
    {
        base.Update();

        EvaluateDecisions(
            parentMaze,
            GameManager.Instance.Players,
            GameManager.Instance.SpawnedCollectibles,
            GameManager.Instance.TimeRemaining
            );
    }

    protected override Vector2Int GetNextPathTile()
    {
        if (pathTilesQueue.Count > 0)
        {
            return pathTilesQueue.Dequeue();
        }

        return base.GetNextPathTile();
    }

    public Queue<Vector2Int> GetPathFromTo(Vector2Int srcTile, Vector2Int destTile)
    {
        // TODO: Implement this method to make it retrieve the path from the source tile to destination tile
        //       so you can use it in the "derived bots"

        Queue<Vector2Int> path = new Queue<Vector2Int>();
        Queue<Vector2Int> closedSet = new Queue<Vector2Int>();
        SimplePriorityQueue<Vector2Int> openSet = new SimplePriorityQueue<Vector2Int>();

        openSet.Enqueue(srcTile, Heuristic(srcTile, destTile));

        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float>();

        for (int row = 0; row < parentMaze.MazeTiles.Count; row++)
        {
            for (int col = 0; col < parentMaze.MazeTiles[0].Count; col++)
            {
                gScore.Add(new Vector2Int(col, row), Mathf.Infinity);
            }
        }
        gScore[srcTile] = 0;
        Vector2Int current = srcTile;

        while (openSet.Count > 0)
        {
            current = openSet.Dequeue();
            if (current == destTile)
            {
                path = ReconstructPath(cameFrom, current, srcTile);
                break;
            }
            closedSet.Enqueue(current);
            foreach (Vector2Int neighbor in parentMaze.GetNeighbors(current.y, current.x))
            {
                if (closedSet.Contains(neighbor) || openSet.Contains(neighbor))
                {
                    continue;
                }
                else
                {
                    openSet.Enqueue(neighbor, gScore[neighbor] + Heuristic(neighbor, destTile));
                }
                float tentative_gScore = gScore[current] + Heuristic(current, neighbor);
                if (tentative_gScore >= gScore[neighbor])
                {
                    continue;
                }
                cameFrom[neighbor] = current;
                gScore[neighbor] = tentative_gScore;
                openSet.UpdatePriority(neighbor, gScore[neighbor] + Heuristic(neighbor, destTile));
            }
        }

        return path;
    }

    public Queue<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current, Vector2 start)
    {
        List<Vector2Int> total_path = new List<Vector2Int>();
        total_path.Add(current);
        while (current != start)
        {
            foreach (var wp in cameFrom.Keys)
            {
                if (wp == current)
                {
                    current = cameFrom[wp];
                    total_path.Add(current);
                }
            }
        }
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        for(int i = total_path.Count - 1; i >=0; i--)
        {
            queue.Enqueue(total_path[i]);
        }
        
        return queue;
    }

    private float Heuristic(Vector2Int p1, Vector2Int p2)
    {
        return Vector3.Distance(parentMaze.GetWorldPositionForMazeTile(p1), parentMaze.GetWorldPositionForMazeTile(p2));
    }

    // TODO: To complete this assignment, you will need to write 
    //       a fair amount of code. It is recommended to create
    //       custom classes/functions to decouple the computations.

    //       The method EvaluateDecisions should be the place where the final decision
    //       should be computed. The bot automatically follows the path which is
    //       described in the "pathTilesQueue" variable. All neighboring values inside
    //       this queue must be 4-neighbors, i.e., the bot can walk only
    //       up/down/left/right with a step of one.
    //      
    //       You do not have to use all arguments of this function 
    //       and you can add even more parameters if you would like to do so.
    //       Tiles of the maze can be accessed via maze.MazeTiles.
    //       Human player is the first player in the "players" list.
    //       CollectibleItem class contains TileLocation property providing information about collectible's position
    //       and Type property retrieving its type.
    //       Good luck. May your bots remain unbeaten by a human player. :)
    protected abstract void EvaluateDecisions(Maze maze, List<AbstractPlayer> players,
        List<CollectibleItem> spawnedCollectibles, float remainingGameTime);
}
