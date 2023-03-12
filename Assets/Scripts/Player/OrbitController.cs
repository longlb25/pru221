using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public Transform pivot;
    public float orbitDistance = 2f;
    public float orbitSpeed = 50f;

    private void Update()
    {
        transform.Rotate(0, 0, -1f);
    }
}
