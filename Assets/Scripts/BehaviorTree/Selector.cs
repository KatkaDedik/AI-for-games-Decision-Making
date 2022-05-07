using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    public override TaskStatus Run(ComputerPlayer agent, WorldManager worldManager)
    {
        int failureCount = 0;
        foreach (Task task in children)
        {
            if (task.status != TaskStatus.Failure)
            {
                TaskStatus childrenStatus = task.Run(agent, worldManager);
                if (childrenStatus == TaskStatus.Succes)
                {
                    status = TaskStatus.Succes;
                    return status;
                }
                else if (childrenStatus == TaskStatus.Failure)
                {
                    failureCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                failureCount++;
            }
        }
        if (failureCount == children.Count)
        {
            status = TaskStatus.Failure;
        }
        else
        {
            status = TaskStatus.Running;
        }
        return status;
    }
}
