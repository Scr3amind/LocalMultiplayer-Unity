using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : MonoBehaviour
{
    [SerializeField] private float invincibleTime = 10.0f;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<PowerUpTaker>()?.activateInvincibility(invincibleTime);
        Destroy(gameObject);
    }
}
