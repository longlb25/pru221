using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : CharacterBaseState
{
    public override void EnterState(CreepManager c)
    {
        Debug.Log("collision state");
        //c.GetComponent<Renderer>().material.color = Color.red;
        c.TakeDamage(c.collisionObj.GetComponent<WeaponControl>().damage);

    }

    public override void ExitState(CreepManager c)
    {
        c.isCollize = false;
    }

    public override void UpdateState(CreepManager c)
    {
        if (c.player != null)
        {
            c.SwitchState(c.moveState);
        }
    }
}

