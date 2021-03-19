using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTaker : MonoBehaviour
{
    [SerializeField] PhysicsController physicsController;
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerHealthController playerHealthController;

    private float initialGravity;
    private float initialMoveSpeed;
    private float initialJumpForce;

    private void Start() 
    {
        initialGravity = physicsController.getCurrentGravity();
        initialMoveSpeed = playerController.movespeed;
        initialJumpForce = playerController.jumpForce;
    }

    public void activatePowerUp(PowerUp.PowerUpType powerUpType, float powerUpValue, float powerUpDuration)
    {
        switch (powerUpType)
        {
            case PowerUp.PowerUpType.SuperSpeed:
                activateSuperSpeed(powerUpValue, powerUpDuration);
                break;

            case PowerUp.PowerUpType.Gravity:
                activateLowGravity(powerUpValue, powerUpDuration);
                break;

            case PowerUp.PowerUpType.Invincibility:
                activateInvincibility(powerUpDuration);
                break;

            case PowerUp.PowerUpType.Health:
                addHealth((int)powerUpValue);
                break;

            default:
                return;
        }
    }
    private void activateLowGravity(float newGravity, float effectTime)
    {
        physicsController.changeGravity(newGravity);
        playerController.movespeed *= 0.8f;
        Invoke("deactivateLowGravity", effectTime);

    }

    private void deactivateLowGravity()
    {
        physicsController.changeGravity(initialGravity);
        playerController.movespeed = initialMoveSpeed;
    }

    private void activateSuperSpeed(float speedMultiplicator, float effectTime)
    {
        
        playerController.movespeed *= speedMultiplicator;
        Invoke("deactivateSuperSpeed", effectTime);
    }

    private void deactivateSuperSpeed()
    {
        playerController.movespeed = initialMoveSpeed;
    }

    private void activateInvincibility(float invincibleTime)
    {
        playerHealthController?.becomeInvincible(invincibleTime);
    }

    private void addHealth(int healthToAdd)
    {
        for (int i = 0; i < healthToAdd; i++)
        {
            playerHealthController?.addHealth();   
        }
    }

}
