using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallenObjects : MonoBehaviour
{
    [SerializeField] string poolName; // Name for the pool of the define object
    private GameObject pool;
    private ObjectPooling objectPooling;

    private float YBound = -40;

    // Start is called before the first frame update
    void Start()
    {
        pool = GameObject.Find(poolName);
        objectPooling = pool.GetComponent<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < YBound)
        {
            objectPooling.PutAwayObject(gameObject);
        }
    }
}
