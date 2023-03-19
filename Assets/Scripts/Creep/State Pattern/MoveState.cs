using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager c)
    {
        Debug.Log("move state");
        c.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void ExitState(CharacterStateManager c)
    {

    }

    public override void UpdateState(CharacterStateManager c)
    {
        c.horizontal = Input.GetAxis("Horizontal");
        c.vertical = Input.GetAxis("Vertical");
        c.rigidbody.velocity = new Vector2(c.horizontal * c._speed, c.vertical * c._speed);
        if (c.rigidbody.velocity.magnitude <= 0)
        {
            c.SwitchState(c.idleState);
            Debug.Log("Switch to idle state");
        }
        if (c.isCollize) 
        {
            c.SwitchState(c.colisionState);
        }
    }
}

