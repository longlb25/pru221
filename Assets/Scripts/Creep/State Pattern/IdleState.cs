using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{
    public override void EnterState(CreepManager c)
    {
        Debug.Log("idle state");
        //c.GetComponent<Renderer>().material.color = Color.white;
    }

    public override void ExitState(CreepManager c)
    {
        
    }

    public override void UpdateState(CreepManager c)
    {
        if (c.player != null)
        {
            c.SwitchState(c.moveState);
        }
    }
}
