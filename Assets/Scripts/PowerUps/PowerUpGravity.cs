using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGravity : MonoBehaviour
{
    [SerializeField] private float effectTime = 5f;
    [SerializeField] private float newGravity = 0.5f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<PowerUpTaker>()?.activateLowGravity(newGravity, effectTime);
        Destroy(gameObject);    
    }
}
