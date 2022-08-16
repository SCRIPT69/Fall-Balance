using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{
    [SerializeField] float _bounciness;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Repel(other.gameObject);
        }
    }

    private void Repel(GameObject entity)
    {
        Rigidbody entityRigidbody = entity.GetComponent<Rigidbody>();
        Vector3 forceDirection = entity.transform.position - transform.position;
        entityRigidbody.AddForce(forceDirection * _bounciness, ForceMode.Impulse);
    }
}
