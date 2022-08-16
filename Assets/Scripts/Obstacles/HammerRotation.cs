using UnityEngine;

public class HammerRotation : MonoBehaviour
{
    [SerializeField] float _speed;

    void FixedUpdate()
    {
        transform.Rotate(0, _speed, 0);
    }
}
