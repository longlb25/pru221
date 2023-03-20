using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deffender : WeaponDecorator
{
    public Deffender(IWeapon inner) : base(inner)
    {

    }

    public override void Init()
    {
        Debug.Log("deffender");
        PlayerController.instance.StartDeffender();
    }
}
