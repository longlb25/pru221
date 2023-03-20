using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepManager : MonoBehaviour
{
    CharacterBaseState curState;

    public MoveState moveState = new MoveState();
    public CollisionState colisionState = new CollisionState();
    public IdleState idleState = new IdleState();

    public GameObject expLow;
    public GameObject expMedium;
    public GameObject expHigh;

    public GameObject player;
    public Rigidbody2D rb;

    public int health = 5;
    public int damageAmount = 1;
    public bool isCollize;
    public GameObject collisionObj;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        curState = idleState;
        curState.EnterState(this);
        isCollize = false;
    }

    void Update()
    {
        if (curState != null)
        {
            curState.UpdateState(this);
        }
    }

    //void FixedUpdate()
    //{
    //    Vector2 direction = (player.transform.position - transform.position).normalized;
    //    rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
    //}
    public void SwitchState(CharacterBaseState c)
    {
        if (curState != null)
        {
            c.ExitState(this);
        }
        curState = c;
        if (curState != null)
        {
            c.EnterState(this);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            DropItem();
            MenuController.instance.creepCount++;
            GameController.instance.ReturnToPool(this.gameObject);
        }
    }

    public void DropItem()
    {
        int temp = Random.Range(0, 100);
        GameObject spawnObj;
        if (temp > 0 && temp < 60)
        {
            spawnObj = expLow;
        }
        else if (temp >= 60 && temp < 90)
        {
            spawnObj = expMedium;
        }
        else
        {
            spawnObj = expHigh;
        }
        GameObject item = Instantiate(spawnObj, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            isCollize = true;
            collisionObj = collision.gameObject;
            //TakeDamage(collision.gameObject.GetComponent<WeaponControl>().damage);
        }
    }
}
