using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    [SerializeField] private float effectTime;
    [SerializeField] private float speedMultiplicator = 1.5f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<PowerUpTaker>().activateSuperSpeed(speedMultiplicator, effectTime);
        Destroy(gameObject);    
    }
}
