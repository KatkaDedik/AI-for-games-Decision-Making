using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCondition : Task
{

    public float remainingTimeRequaired = 20f;

    public override TaskStatus Run(ComputerPlayer agent, WorldManager worldManager)
    {
        if(GameManager.Instance.TimeRemaining > remainingTimeRequaired && GameManager.Instance.TimeRemaining < 58)
        {
            status = TaskStatus.Succes;
        }
        else
        {
            status = TaskStatus.Failure;
        }
        return status;
    }

}
