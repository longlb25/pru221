using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour, IWeapon
{
    private IWeapon _weapon;

    public Slash(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Fire()
    {
        // Add silencer effect
        StartCoroutine(testSlash());
        // Call the decorated weapon's Fire method
        _weapon.Fire();
    }
    IEnumerator testSlash()
    {

        while (true)
        {
            Debug.Log("slash");
            yield return new WaitForSeconds(1);
        }
    }
}
