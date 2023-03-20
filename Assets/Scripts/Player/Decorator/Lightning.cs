using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : WeaponDecorator
{
    public Lightning(IWeapon inner) : base(inner)
    {

    }

    public override void Init()
    {
        Debug.Log("lightning");
        PlayerController.instance.StartLightning();
    }
}