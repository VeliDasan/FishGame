using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private int amountObjects = 100;

    private List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField] private GameObject bulletPrefab;

    private void Awake()

    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i=0; i < amountObjects; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledObjects.Add(bullet);
        }
        
    }

    public GameObject GetObjectFromPool()
    {
        for (int i =0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
