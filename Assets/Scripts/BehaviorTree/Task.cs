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
}
