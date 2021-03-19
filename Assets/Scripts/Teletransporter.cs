using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransporter : MonoBehaviour
{
    [SerializeField] private Transform placeToTransport;
    [SerializeField] private AudioClip teletransportSound;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<PhysicsController>().teletransport(placeToTransport.position);
        AudioManager.instance.playSound(teletransportSound);
    }
}
