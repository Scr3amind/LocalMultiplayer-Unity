using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private float bounceForce = 12f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<IDamageable>()?.takeDamage();
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, bounceForce);
    }
}
