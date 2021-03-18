using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsController : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    private void Start() 
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    public void makeItJump(float bounceForce)
    {
        rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, bounceForce);
    }

    public void teletransport(Vector3 newPosition)
    {
        gameObject.SetActive(false);
        transform.position = newPosition;
        gameObject.SetActive(true);
    }

    public void changeGravity(float newGravity)
    {
        rigidBody2d.gravityScale = newGravity;
    }


}
