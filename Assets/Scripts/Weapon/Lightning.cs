using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour, IWeapon
{
    private IWeapon _weapon;

    public Lightning(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Fire()
    {
        // Add silencer effect
        Debug.Log("Pew pew pew (with a silencer)");
        StartCoroutine(testLightning());
        // Call the decorated weapon's Fire method
        _weapon.Fire();
    }

    IEnumerator testLightning()
    {
        while (true)
        {
            Debug.Log("deffender");
            yield return new WaitForSeconds(1);
        }
    }
}