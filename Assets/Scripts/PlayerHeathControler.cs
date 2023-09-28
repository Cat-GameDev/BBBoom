using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeathControler : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    private int currentHealth;
    [SerializeField] private GameObject shieldDisplay;

    private float invincCounter, flashCounter;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
        }
    }
    
   
    
    public void DamagePlayer(int damageToTake)
    {
        if (invincCounter <= 0)
        {

            AudioManager.Instance.PlaySFX(3);
            currentHealth -= damageToTake;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            shieldDisplay.SetActive(false);


            if (currentHealth == 0)
            {

                gameObject.SetActive(false);

                AudioManager.Instance.PlaySFX(2);
            }

            //invincCounter = invincibilityTime;
        }
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        shieldDisplay.SetActive(true);
        flashCounter = 0;
        invincCounter = 0;
    }

}
