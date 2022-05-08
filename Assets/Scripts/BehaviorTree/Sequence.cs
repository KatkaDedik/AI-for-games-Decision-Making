using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{

    public override TaskStatus Run(ComputerPlayer agent, WorldManager worldManager)
    {
        int successCount = 0;
        foreach(Task task in children)
        {
            if (task.status != TaskStatus.Succes)
            {
                TaskStatus childrenStatus = task.Run(agent, worldManager);
                if (childrenStatus == TaskStatus.Failure)
                {
                    status = TaskStatus.Failure;
                    return status;
                }
                else if (childrenStatus == TaskStatus.Succes)
                {
                    successCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                successCount++;
            }
        }
        if (successCount == children.Count)
        {
            status = TaskStatus.Succes;
            SetStatus(TaskStatus.Succes, TaskStatus.None);
            status = TaskStatus.Succes;
        }
        else
        {
            status = TaskStatus.Running;
        }
        return status;
    }
}
