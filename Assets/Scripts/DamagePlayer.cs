using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int damageToDeal = 1;
    [SerializeField] private AudioClip damageSound;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<IDamageable>()?.takeDamage(damageToDeal); 
        AudioManager.instance.playSound(damageSound);
    }
}
