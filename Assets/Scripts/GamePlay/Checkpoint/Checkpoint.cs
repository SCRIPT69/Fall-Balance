using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int _number; // 0 if spawn
    public int Number
    {
        get
        {
            return _number;
        }
        private set
        {
            _number = value;
        }
    }

    [SerializeField] bool _isGrid;
    [SerializeField] float _interval = 2.99f;

    private int _cellPositionByZ;
    private int _cellPositionByX;

    void Start()
    {
        Number = _number;
        if (_isGrid)
        {
            _cellPositionByZ = 0;
            _cellPositionByX = 0;
        }

        GameObject ply = GameObject.Find("Player");
        SetToGrid(ply);
    }

    public void SetToGrid(GameObject entity)
    {
        if (_isGrid)
        {
            float z = transform.position.z + (transform.lossyScale.z / 2) - _cellPositionByZ * _interval;
            float x = transform.position.x + (transform.lossyScale.x / 2) - _cellPositionByX * _interval;

            if (z < transform.position.z - (transform.lossyScale.z / 2)) // if out of z bound
            {
                _cellPositionByZ = 0; // resetting z position
                z = transform.position.z + (transform.lossyScale.z / 2) - _cellPositionByZ * _interval;

                _cellPositionByX++; // moving x position
                x = transform.position.x + (transform.lossyScale.x / 2) - _cellPositionByX * _interval;
                if (x < transform.position.x - (transform.lossyScale.x / 2)) // if out of x bound
                {
                    throw new System.Exception("Not enough slots");
                }
            }

            float y = transform.position.y - transform.lossyScale.y / 2;

            _cellPositionByZ++;

            entity.transform.position = new Vector3(x, y, z);
        }
    }

    public void Respawn(GameObject entity)
    {
        float x = generateRandomPosition(transform.position.x - (transform.lossyScale.x / 2), transform.position.x + (transform.lossyScale.x / 2));
        float z = generateRandomPosition(transform.position.z - (transform.lossyScale.z / 2), transform.position.z + (transform.lossyScale.z / 2));
        float y = transform.position.y - transform.lossyScale.y / 2;

        Rigidbody entityRigidbody = entity.GetComponent<Rigidbody>();
        entityRigidbody.velocity = Vector3.zero;
        entityRigidbody.angularVelocity = Vector3.zero;
        entity.transform.position = new Vector3(x, y, z);
    }

    private float generateRandomPosition(float startPos, float endPos)
    {
        return Random.Range(startPos, endPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Number != 0) // if it's not spawn
        {
            CurrentCheckpointOfPlayer currentCheckpointComponent = other.gameObject.GetComponent<CurrentCheckpointOfPlayer>();
            if (currentCheckpointComponent is not null)
            {
                if (currentCheckpointComponent.CurrentCheckpoint.Number < Number)
                {
                    currentCheckpointComponent.CurrentCheckpoint = this;
                }
            }
        }
    }
}
