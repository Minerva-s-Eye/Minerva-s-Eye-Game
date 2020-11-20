using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss: MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;



    public Health healthBar;

    // Start is called before the first frame update

    void Start()
    {
    
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
           
        
    
    public void TakeDamage(int damage)
        {

            currentHealth -= 1;

            healthBar.SetHealth(currentHealth);

        }
        
    
}
