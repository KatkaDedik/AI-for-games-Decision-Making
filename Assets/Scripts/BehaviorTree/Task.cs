using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskStatus
{
    None,
    Succes,
    Failure,
    Running
}

public abstract class Task
{

    protected List<Task> children;
    public TaskStatus status;

    public abstract TaskStatus Run(ComputerPlayer agent, WorldManager worldManager);

    public Task()
    {
        children = new List<Task>();
        status = TaskStatus.None;
    }

    public void AddChildren(Task task)
    {
        children.Add(task);
    }

    public void SetStatus(TaskStatus conditionStatus, TaskStatus to)
    {
        if (status == conditionStatus)
        {
            status = to;
            foreach (var child in children)
            {
                child.SetStatus(conditionStatus, to);
            }
        }
    }
    public void SetStatus(TaskStatus to)
    {

        status = to;
        foreach (var child in children)
        {
            child.SetStatus(to);
        }
    }
}
