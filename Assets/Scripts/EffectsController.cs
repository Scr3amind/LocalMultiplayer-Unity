using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private GameObject spawnEffectParticles;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    void spawnEffect() 
    {
        Instantiate(spawnEffectParticles, transform.position, transform.rotation);
    }

    void deadEffect() 
    {
        
    }

    public void switchCharacterEffect() 
    {
        spawnEffect();
    }

    public void invincibilityEffect() 
    {
        StartCoroutine("blink");
        // spriteRenderer.color = new Color(0.8f, 0.5f, 0.5f, 1.0f);
    }

    private IEnumerator blink()
    {
        while(true) {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void backToMortalEffect()
    {
        StopCoroutine("blink");
        // spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        spriteRenderer.enabled = true;
    }
    private void OnEnable() 
    {
        spawnEffect();
    }

    private void Update() 
    {
        
    }


}
