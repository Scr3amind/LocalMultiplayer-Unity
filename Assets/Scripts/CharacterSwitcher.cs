using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private EffectsController effectsController = null;
    
    // Start is called before the first frame update
    public void switchCharacter(AnimatorOverrideController otherCharacterAnimator)
    {
        effectsController?.switchCharacterEffect();
        playerAnimator.runtimeAnimatorController = otherCharacterAnimator;
    }
}
