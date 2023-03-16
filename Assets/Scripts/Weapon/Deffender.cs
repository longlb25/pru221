using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deffender : MonoBehaviour, IWeapon
{
    private IWeapon _weapon;

    public Deffender(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Fire()
    {
        // Add silencer effect
        //Debug.Log("Pew pew pew (with a silencer)");
        StartCoroutine(testDeffender());
        // Call the decorated weapon's Fire method
        _weapon.Fire();
    }

    IEnumerator testDeffender()
    {
        while (true)
        {
            Debug.Log("deffender");
            yield return new WaitForSeconds(1);
        }
    }
}
