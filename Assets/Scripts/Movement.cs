using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool _isOnPlatform = false;
    private Rigidbody _targetRigidbody;

    void Start()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isOnPlatform = true;
        }
        else
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
