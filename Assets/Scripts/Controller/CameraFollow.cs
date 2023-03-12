using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraOffset = new Vector3(0, 0, -10); // the offset to the camera position
        transform.position = player.transform.position + cameraOffset;
        float smoothTime = 0.3f; // the time it takes for the camera to move towards the target position
        Vector3 velocity = Vector3.zero; // the velocity of the camera movement
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + cameraOffset, ref velocity, smoothTime);

    }
}
