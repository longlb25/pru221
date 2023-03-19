using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStateManager : MonoBehaviour
{
    CharacterBaseState currentState;

    public UnityEvent onStateChange;

    public MoveState moveState = new MoveState();
    public CollisionState colisionState = new CollisionState();
    public IdleState idleState = new IdleState();

    public float _speed;
    public float vertical, horizontal;

    public bool isCollize;

    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentState = idleState;
        currentState.EnterState(this);
        isCollize = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void SwitchState(CharacterBaseState c)
    {
        if (currentState != null)
        {
            c.ExitState(this);
        }
        currentState = c;
        if (currentState != null)
        {
            c.EnterState(this);
            //onStateChange.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        { 
            isCollize = true;
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        isCollize = false;
    //    }
    //}
}
