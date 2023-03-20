using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CharacterBaseState
{
    public override void EnterState(CreepManager c)
    {
        Debug.Log("move state");
        //c.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void ExitState(CreepManager c)
    {

    }

    public override void UpdateState(CreepManager c)
    {
        Vector2 direction = (c.player.transform.position - c.transform.position).normalized;
        c.rb.MovePosition(c.rb.position + direction * Time.deltaTime);
        if (c.player == null)
        {
            c.SwitchState(c.idleState);
        }
        if (c.isCollize)
        {
            c.SwitchState(c.colisionState);
        }
    }
}

