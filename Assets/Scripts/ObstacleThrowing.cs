using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThrowing : MonoBehaviour
{
    [SerializeField] GameObject pool;
    private ObjectPooling objectPooling;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Vector3 direction;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    private float maxTorque = 10000;

    // Start is called before the first frame update
    void Start()
    {
        objectPooling = pool.GetComponent<ObjectPooling>();
        //Invoke("ThrowObstacle", Random.Range(minTime, maxTime));
        StartCoroutine(StartThrowingObstaclesCycle());
    }

    IEnumerator StartThrowingObstaclesCycle()
    {
        // Cycle to spawn flying from the tube obstacles
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            GameObject obstacle = objectPooling.SpawnObject(obstaclePrefab.transform.position, obstaclePrefab.transform.rotation);
            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            obstacleRigidbody.AddForce(direction * randomSpeed, ForceMode.Impulse);
            obstacleRigidbody.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque());
        }
        //Invoke("ThrowObstacle", Random.Range(minTime, maxTime));
    }

    float GetRandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
