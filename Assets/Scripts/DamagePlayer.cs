using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int damageToDeal;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<IDamageable>()?.takeDamage();    
    }
}
