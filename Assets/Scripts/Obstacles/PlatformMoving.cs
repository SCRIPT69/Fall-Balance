using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _delay;
    [SerializeField] float _minBound;
    [SerializeField] float _maxBound;
    [SerializeField] bool _startDirectionPositive = true;
    private int _direction = 1;

    enum Axes
    {
        X,
        Y,
        Z
    }
    [SerializeField] Axes _axis;
    private Vector3[] _vectorsForAxes = new Vector3[] { Vector3.right, Vector3.up, Vector3.forward };

    private bool _canMove = true;

    void Start()
    {
        if (!_startDirectionPositive)
        {
            _direction *= -1; //changing direction to negative
        }
        StartCoroutine(StartMovingCycle());
    }

    IEnumerator StartMovingCycle()
    {
        while (true)
        {
            //waiting for the platform to approach its borders
            yield return new WaitUntil(() => getMovingAxis() < _minBound || getMovingAxis() > _maxBound);

            //delay
            _canMove = false;
            yield return new WaitForSeconds(_delay);

            //changing direction
            _direction *= -1;
            _canMove = true;

            yield return new WaitForSeconds(0.1f); //giving time for the platform to leave the border
        }
    }
    private float getMovingAxis()
    {
        float[] axes = new float[] { transform.position.x, transform.position.y, transform.position.z };
        return axes[(int)_axis];
    }



    void Update()
    {
        if (_canMove)
        {
            transform.Translate(_vectorsForAxes[(int)_axis] * Time.deltaTime * _speed * _direction);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() is not null)
        {
            Rigidbody entityRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            entityRigidbody.AddForce(getPlatformMovingVector());
        }
    }

    private Vector3 getPlatformMovingVector()
    {
        Vector3 platformMovingVector = _vectorsForAxes[(int)_axis] * Mathf.Floor(_speed * _direction / 3);
        if (!_canMove)
        {
            platformMovingVector *= 0;
        }
        return platformMovingVector;
    }
}
