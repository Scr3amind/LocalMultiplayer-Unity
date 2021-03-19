using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private int damageToDeal = 1;
    [SerializeField] private float bounceForce = 12f;
    [SerializeField] private AudioClip stompSound;
    
    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<IDamageable>()?.takeDamage(damageToDeal);
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, bounceForce);
        AudioManager.instance.playSound(stompSound);
    }
}
