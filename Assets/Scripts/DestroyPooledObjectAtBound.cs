using UnityEngine;

public class DestroyPooledObjectAtBound : MonoBehaviour
{
    [SerializeField] string _poolName; // Name for the pool of the define object
    private GameObject _pool;
    private ObjectPooling _objectPooling;

    void Start()
    {
        _pool = GameObject.Find(_poolName);
        _objectPooling = _pool.GetComponent<ObjectPooling>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bound"))
        {
            _objectPooling.PutAwayObject(gameObject);
        }
    }
}
