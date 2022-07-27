using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private Movement _movement;

    private float _speed = 5;
    private GameObject _player;
    private Rigidbody _enemyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _movement = GetComponent<Movement>();
        _enemyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _movement.AddForce(lookDirection * _speed);
        //_enemyRigidbody.AddForce(lookDirection * _speed);
    }
}
