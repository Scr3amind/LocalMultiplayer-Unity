using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBouncer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float xAxisLimit = 15.0f;
    [SerializeField] private float yAxisLimit = 6.5f;
    private Vector3 moveDirection;
    
    private void Start() 
    {
        moveDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        moveDirection = moveDirection.normalized;
    }

    private void FixedUpdate() 
    {
        getMoveDirection();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);    
    }

    private void getMoveDirection()
    {
        if(transform.position.x < -xAxisLimit || transform.position.x > xAxisLimit)
        {
            moveDirection = new Vector3(-moveDirection.x, moveDirection.y);
        }
        else if (transform.position.y < -yAxisLimit || transform.position.y > yAxisLimit)
        {
            moveDirection = new Vector3(moveDirection.x, -moveDirection.y);
        }

    }

}
