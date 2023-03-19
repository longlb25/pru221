using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] float _speed;
    float vertical, horizontal;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //currentState = idleState;
        //currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }


    public void Idle()
    {
        if (!Input.anyKey)
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Moving()
    {
        if (Input.anyKeyDown)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;  
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(horizontal * _speed, vertical * _speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("hit");
            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}
