using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRotation : MonoBehaviour
{
    private class RotationAxis
    {
        public bool IsAtStartPosition = true;
        public float Direction = 3;

        public float RotationTime;
    }

    private RotationAxis XRotation = new RotationAxis();
    private RotationAxis ZRotation = new RotationAxis();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRotation(XRotation));
        StartCoroutine(StartRotation(ZRotation));
    }


    IEnumerator StartRotation(RotationAxis axis)
    {
        while (true)
        {
            if (axis.IsAtStartPosition)
            {
                axis.Direction = GenerateRandomDirection(axis.Direction);
                axis.RotationTime = Random.Range(3, 10);
            }
            else
            {
                axis.Direction = -axis.Direction;
            }
            axis.IsAtStartPosition = !axis.IsAtStartPosition;

            yield return new WaitForSeconds(axis.RotationTime);
        }
    }

    float GenerateRandomDirection(float distance)
    {
        float direction = distance;
        if ( Random.Range(0, 2) == 0) // Random number: 0 or 1, if 0, then direction will be changed
        {
            direction *= -1;
        }
        return direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, XRotation.Direction * Time.deltaTime);
        transform.Rotate(Vector3.right, ZRotation.Direction * Time.deltaTime);
    }
}
