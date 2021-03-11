using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectorButton : MonoBehaviour
{
    [SerializeField] private Sprite buttonUp, buttonDown;
    [SerializeField] private Sprite characterToSwitch = null;
    [SerializeField] private AnimatorOverrideController characterAnimator = null;
    [SerializeField] private SpriteRenderer buttonRenderer = null;
    [SerializeField] private SpriteRenderer characterRenderer = null;
    [SerializeField] private BoxCollider2D buttonCollider = null;

    // Start is called before the first frame update
    void Start()
    {
        characterRenderer.sprite = characterToSwitch;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        buttonRenderer.sprite = buttonDown;
        buttonCollider.enabled = false;
        other.GetComponent<CharacterSwitcher>()?.switchCharacter(characterAnimator);

        
    }

    private void OnTriggerExit2D(Collider2D other) {
        buttonRenderer.sprite = buttonUp;
        buttonCollider.enabled = true;
    }
    
}
