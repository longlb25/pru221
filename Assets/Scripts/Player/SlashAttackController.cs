using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Enemy"))
        //{
        //    // Do damage to the enemy
        //    //other.GetComponent<EnemyController>().TakeDamage(damageAmount);
        //}
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce enemy's health by the damage amount
        
    }


}
