using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CurrentCheckpointOfPlayer currentCheckpointComponent = other.gameObject.GetComponent<CurrentCheckpointOfPlayer>();
        if (currentCheckpointComponent is not null)
        {
            currentCheckpointComponent.CurrentCheckpoint.Respawn(other.gameObject);
        }
    }
}
