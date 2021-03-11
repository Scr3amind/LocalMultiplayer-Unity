using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private int initialHealthPoints = 3;
    [SerializeField] private Transform heartHolder = null;
    [SerializeField] private HeartController heartPrefab = null;
    [SerializeField] private float invincibilityTime = 0.5f;
    [SerializeField] private EffectsController effectsController = null;
    private List<HeartController> heartsList = new List<HeartController>();
    private float heartPositionX = -0.5f;
    private int healthPoints = 0;
    private int currentNumberOfHearts = 0;
    public bool isInvincible = false;


    // Start is called before the first frame update
    void Start()
    {
        initializeHealth();
    }
    void Update() {
        if(Keyboard.current.gKey.wasPressedThisFrame)
        {
            addHealth();
           
        }
    }
    void LateUpdate() {
        // dont flip hearts
        heartHolder.localScale = new Vector3(transform.localScale.x, heartHolder.localScale.y, heartHolder.localScale.z);
    }
    public void initializeHealth()
    {
        for (int i = 0; i < initialHealthPoints; i++)
        {
            addHealth();
        }
    }

    public void emptyHealth()
    {   

        while(healthPoints > 0)
        {
            reduceHealth();
        }
    }
    void addHeart() 
    {
        HeartController currentHeart;
        currentHeart = Instantiate(heartPrefab);
        currentHeart.transform.SetParent(heartHolder);
        currentHeart.transform.localPosition = new Vector3(heartPositionX, 0, 0);
        heartsList.Add(currentHeart);
        heartPositionX += 0.5f;

        currentNumberOfHearts ++;

    }

    void removeHeart()
    {
        GameObject extraHeart = heartsList[healthPoints].gameObject;
        heartsList.RemoveAt(healthPoints);
        Destroy(extraHeart);
        heartPositionX -= 0.5f;
        currentNumberOfHearts--;
    }


    void addHealth()
    {
        healthPoints++;
        if(healthPoints > currentNumberOfHearts)
        {
            addHeart();
        }
        else {
            heartsList[healthPoints - 1].makeFull();
        }
    }

    public void takeDamage()
    {
        if (isInvincible) return;
        reduceHealth();
        becomeInvincible();

        if(healthPoints < 1) {
            die();
        }

    }

    public void reduceHealth()
    {
        if(healthPoints < 0) return;

        healthPoints--;
        if(healthPoints >= initialHealthPoints)
        {
            removeHeart();
        }
        else 
        {
            heartsList[healthPoints].makeEmpty();
        }
    }
    void die() {
        gameObject.SetActive(false);
    }

    void becomeInvincible() 
    {
        isInvincible = true;
        effectsController?.invincibilityEffect();
        Invoke("becomeMortal", invincibilityTime);

    }

    void becomeMortal()
    {
        isInvincible = false;
        effectsController?.backToMortalEffect();
    }

}
