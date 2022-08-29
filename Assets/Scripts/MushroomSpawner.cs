using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    //public GameObject objPrefab;
    
    //public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
       // SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    void FixedUpdate(){
        // Instantiate(objPrefab, transform.position, Quaternion.identity);
        GameObject mushroom = GetPooledObject();
        if (mushroom != null)
        {
            mushroom.transform.position = transform.position;
            mushroom.transform.rotation = transform.rotation;
            mushroom.SetActive(true);
        }
        else if (mushroom ==null)
        {
            addOnPool();
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    private void addOnPool()
    {
        GameObject tmp;
        tmp = Instantiate(objectToPool,transform);
        tmp.SetActive(true);
        pooledObjects.Add(tmp);
    }

}
