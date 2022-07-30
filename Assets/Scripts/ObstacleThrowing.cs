using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThrowing : MonoBehaviour
{
    [SerializeField] GameObject _pool;
    private ObjectPooling _objectPooling;

    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] Vector3 _direction;

    [SerializeField] float _minTime;
    [SerializeField] float _maxTime;

    private float _maxTorque = 10000;

    void Start()
    {
        _objectPooling = _pool.GetComponent<ObjectPooling>();
        StartCoroutine(StartThrowingObstaclesCycle());
    }

    IEnumerator StartThrowingObstaclesCycle()
    {
        // Cycle to spawn flying from the tube obstacles
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));

            GameObject obstacle = _objectPooling.SpawnObject(_obstaclePrefab.transform.position, _obstaclePrefab.transform.rotation);
            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();
            float randomSpeed = Random.Range(_minSpeed, _maxSpeed);
            obstacleRigidbody.AddForce(_direction * randomSpeed, ForceMode.Impulse);
            obstacleRigidbody.AddTorque(getRandomTorque(), getRandomTorque(), getRandomTorque());
        }
    }
    private float getRandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
}
