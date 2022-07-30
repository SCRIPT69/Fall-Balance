using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private Movement _movement;

    private float _speed = 7.4f;
    private GameObject _player;
    private Rigidbody _enemyRigidbody;

    void Start()
    {
        _player = GameObject.Find("Player");
        _movement = GetComponent<Movement>();
        _enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _movement.AddForce(lookDirection * _speed);
        //_enemyRigidbody.AddForce(lookDirection * _speed);
    }
}
