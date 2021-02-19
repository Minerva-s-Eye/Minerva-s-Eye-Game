using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss: MonoBehaviour
{

    public int maxHealth = 10;
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
        if (currentHealth < 1) { Button_do_thing("ded 3"); }

        }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }

}
