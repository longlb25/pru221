using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager c)
    {
        Debug.Log("idle state");
        c.GetComponent<Renderer>().material.color = Color.white;
    }

    public override void ExitState(CharacterStateManager c)
    {
        
    }

    public override void UpdateState(CharacterStateManager c)
    {
        if (Input.anyKeyDown)
        {
            c.SwitchState(c.moveState);
            Debug.Log("switch to move state");
        }
        if (c.isCollize)
        {
            c.SwitchState(c.colisionState);
        }
    }
}
