using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallenObjects : MonoBehaviour
{
    [SerializeField] string _poolName; // Name for the pool of the define object
    private GameObject _pool;
    private ObjectPooling _objectPooling;

    private float _YBound = -40;

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.Find(_poolName);
        _objectPooling = _pool.GetComponent<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < _YBound)
        {
            _objectPooling.PutAwayObject(gameObject);
        }
    }
}
