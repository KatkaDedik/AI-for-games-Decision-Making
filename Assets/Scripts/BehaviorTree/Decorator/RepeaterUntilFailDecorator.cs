using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterUntilFailDecorator : Task
{
    Task child;
    public override TaskStatus Run(ComputerPlayer agent, WorldManager worldManager)
    {
        if(status != TaskStatus.Failure)
        {
            status = TaskStatus.Running;
            child.SetStatus(TaskStatus.Running);
        }

        if(child.Run(agent, worldManager) == TaskStatus.Failure){
            status = TaskStatus.Succes;
        }
        return status;
    }

    public void AddChildren(Task task)
    {
        child = task;
    }
}
