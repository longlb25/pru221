using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager c)
    {
        Debug.Log("collision state");
        c.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void ExitState(CharacterStateManager c)
    {
        c.isCollize = false;
    }

    public override void UpdateState(CharacterStateManager c)
    {
        if (Input.anyKeyDown)
        {
            c.SwitchState(c.moveState);
            Debug.Log("switch to move state");
        }
        if (c.rigidbody.velocity.magnitude <= 0 && !c.isCollize)
        {
            c.SwitchState(c.idleState);
            Debug.Log("Switch to idle state");
        }
    }
}

