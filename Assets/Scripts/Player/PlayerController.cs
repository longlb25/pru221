using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float speed = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
}
