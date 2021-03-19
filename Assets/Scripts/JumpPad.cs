using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpPad : MonoBehaviour
{
    [SerializeField] private Sprite jumpPadDownSprite;
    [SerializeField] private Sprite jumpPadUpSprite;
    [SerializeField] private float activeTime = 0.5f;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private AudioClip jumpPadSound;
    private SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        deActivateJumpPad();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<PhysicsController>()?.makeItJump(jumpForce);
        activateJumpPad();
        AudioManager.instance.playSound(jumpPadSound);
    }

    private void activateJumpPad()
    {
        spriteRenderer.sprite = jumpPadUpSprite;
        Invoke("deActivateJumpPad", activeTime);
    }
    private void deActivateJumpPad()
    {
        spriteRenderer.sprite = jumpPadDownSprite;
    }
}
