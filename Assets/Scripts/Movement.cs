using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool _isOnPlatform = false;
    private Rigidbody _targetRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isOnPlatform = false;
        }
    }
    
    // The method for encapsulation of movement logic and conditions
    public void AddForce(Vector3 movementDirection)
    {
        // The target can only move when it is on the platform
        if (_isOnPlatform)
        {
            _targetRigidbody.AddForce(movementDirection);
        }
    }
}
