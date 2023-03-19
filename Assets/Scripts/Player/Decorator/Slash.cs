using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : WeaponDecorator
{
    public Slash(IWeapon inner) : base(inner)
    {

    }

    public override void Init()
    {
        Debug.Log("slash");
        PlayerController.instance.StartSlash();
    }
}
