using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType {SuperSpeed, Gravity, Invincibility, Health};

    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float powerUpValue;
    [SerializeField] private float powerUpDuration;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<PowerUpTaker>()?.activatePowerUp(powerUpType, powerUpValue, powerUpDuration);
        Destroy(gameObject);    
    }
}
