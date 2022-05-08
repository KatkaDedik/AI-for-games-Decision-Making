using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCondition : Task
{

    private float remainingTimeRequaired = 20f;


    public TimeCondition(float until)
    {
        remainingTimeRequaired = until;
    }

    public override TaskStatus Run(ComputerPlayer agent, WorldManager worldManager)
    {
        if(GameManager.Instance.TimeRemaining > remainingTimeRequaired)
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
