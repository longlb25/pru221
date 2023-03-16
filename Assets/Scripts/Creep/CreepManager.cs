using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepManager : MonoBehaviour
{
    public GameObject expLow;
    public GameObject expMedium;
    public GameObject expHigh;

    public GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);
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
            DropItem();
            GameController.instance.ReturnToPool(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
