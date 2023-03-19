using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    private IWeapon weapon;

    public WeaponDecorator(IWeapon inner)
    {
        weapon = inner;
    }

    public virtual void Init()
    {

    }

}
