using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float movespeed, jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenAttacks = 0.25f;

    private bool isGrounded = false;
    private bool canMove = true;
    private float horizontalDirection;

    // Start is called before the first frame update
    private void Start() {
        DontDestroyOnLoad(gameObject);
        GameManager.instance.addPlayer(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIfIsGrounded();
        setHorizontalVelocity();
        limitMovementIfAttacking();
        setAnimator();
    }

    void limitMovementIfAttacking()
    {
        if(!canMove){
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }

    void setHorizontalVelocity()
    {
        rb.velocity = new Vector2(horizontalDirection * movespeed, rb.velocity.y);
    }

    void checkIfIsGrounded() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundLayerMask);
    }
    void setAnimator()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("ySpeed", rb.velocity.y);
        
    }

    void flipCharacterToMoveDirection()
    {
        float direction = Mathf.Sign(horizontalDirection);

        if(horizontalDirection != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalDirection = context.ReadValue<Vector2>().x;
        flipCharacterToMoveDirection();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // shorter Jumps

        if(!isGrounded && context.canceled && rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            pauseAndRestartMovement();
            animator.SetTrigger("attack");
        }
    }

    void pauseAndRestartMovement()
    {
        canMove = false;
        Invoke("restartMovement", timeBetweenAttacks);
    }

    void restartMovement() 
    {
        canMove = true;
    }
}
