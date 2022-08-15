using UnityEngine;

public class HammerRotation : MonoBehaviour
{
    [SerializeField] GameObject _hammer;
    private Rigidbody _hammerRigidbody;
    [SerializeField] float _speed;

    void Start()
    {
        _hammerRigidbody = _hammer.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, _speed, 0);
    }
}
