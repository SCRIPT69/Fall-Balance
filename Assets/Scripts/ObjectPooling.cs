using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
To use this script, create empty objects for each game objects to be pooled
and attach this script to this empty objects and set it

Use SpawnObject() to get object with set position and rotation
Use PutAwayObject() to deactivate object
*/
public class ObjectPooling : MonoBehaviour
{
    [SerializeField] int objectsAmount;
    [SerializeField] GameObject objectToPool;
    private List<GameObject> _pooledObjects;

    void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < objectsAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj = getFreeObjectFromPool();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }
    private GameObject getFreeObjectFromPool()
    {
        foreach (GameObject obj in _pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        throw new System.Exception("Not enough objects in the pool");
    }

    public void PutAwayObject(GameObject obj)
    {
        obj.SetActive(false);
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        objRigidbody.velocity = new Vector3(0, 0, 0);
        objRigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
}
