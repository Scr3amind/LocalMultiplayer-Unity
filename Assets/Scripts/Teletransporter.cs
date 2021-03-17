using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporter : MonoBehaviour
{
    [SerializeField] private Transform placeToTransport;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<PhysicsController>().teletransport(placeToTransport.position);
    }
}
