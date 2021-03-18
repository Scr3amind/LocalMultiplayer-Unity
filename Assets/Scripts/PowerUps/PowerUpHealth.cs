using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    [SerializeField] private int healthToAdd = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<PowerUpTaker>()?.addHealth(healthToAdd);
        Destroy(gameObject);
    }
}
