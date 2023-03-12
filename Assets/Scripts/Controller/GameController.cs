using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject creep1;
    public GameObject creep2;
    public GameObject creep3;

    public int poolSize;

    public List<GameObject> pooledObjects1;
    public List<GameObject> pooledObjects2;
    public List<GameObject> pooledObjects3;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            instance = null;
        }
        else
        {
            instance = this;
        }

        for (int i = 0; i < poolSize; i++)
        {
            //Instantiate game object
            GameObject obj = Instantiate(creep1);
            GameObject obj2 = Instantiate(creep2);
            GameObject obj3 = Instantiate(creep3);
            obj.transform.parent = this.transform;
            obj2.transform.parent = this.transform;
            obj3.transform.parent = this.transform;

            //set game object to false so the game object won't show up on the screen
            obj.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);

            //Add game object to the pool
            pooledObjects1.Add(obj);
            pooledObjects2.Add(obj2);
            pooledObjects3.Add(obj3);

        }

        SpawnWave(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave(int waveNumber, int numMonsters)
    {
        for (int i = 0; i < numMonsters; i++)
        {
            int monsterType = Random.Range(1, 4); // choose a random monster type
            GameObject monster = null;
            if (monsterType == 1)
            {
                monster = GetMonster1();
            }
            else if (monsterType == 2)
            {
                monster = GetMonster2();
            }
            else if (monsterType == 3)
            {
                monster = GetMonster3();
            }

            // code to position and orient the monster
            monster.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }
    }


    public GameObject GetMonster1()
    {
        if (pooledObjects1.Count > 0)
        {
            GameObject pooledObject = pooledObjects1[0];
            pooledObjects1.RemoveAt(0);
            pooledObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            GameObject newObject = Instantiate(creep1);
            newObject.SetActive(true);
            return newObject;
        }
    }

    public GameObject GetMonster2()
    {
        if (pooledObjects2.Count > 0)
        {
            GameObject pooledObject = pooledObjects2[0];
            pooledObjects2.RemoveAt(0);
            pooledObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            GameObject newObject = Instantiate(creep2);
            newObject.SetActive(true);
            return newObject;
        }
    }

    public GameObject GetMonster3()
    {
        if (pooledObjects3.Count > 0)
        {
            GameObject pooledObject = pooledObjects3[0];
            pooledObjects3.RemoveAt(0);
            pooledObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            GameObject newObject = Instantiate(creep3);
            newObject.SetActive(true);
            return newObject;
        }
    }

    public void ReturnToPool(GameObject pooledObject)
    {
        if (pooledObject.CompareTag("Creep1"))
        {
            pooledObject.SetActive(false);
            pooledObjects1.Add(pooledObject);
        }
        else if (pooledObject.CompareTag("Creep2"))
        {
            pooledObject.SetActive(false);
            pooledObjects2.Add(pooledObject);
        }
        else if (pooledObject.CompareTag("Creep3"))
        {
            pooledObject.SetActive(false);
            pooledObjects3.Add(pooledObject);
        }
    }
}
