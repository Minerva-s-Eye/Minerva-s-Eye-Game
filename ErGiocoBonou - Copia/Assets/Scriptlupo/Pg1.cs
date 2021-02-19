using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pg1 : MonoBehaviour
{

    public int  maxHealth = 10000;
    public int currentHealth;
    public int vitaPersa = 1;


    public Health1 healthBar;

    // Start is called before the first frame update

    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    public void FixedUpdate()
    {

        currentHealth -= vitaPersa;
        healthBar.SetHealth(currentHealth);

    }



    public void Heal(int damage)
    {

        currentHealth += 500;

        healthBar.SetHealth(currentHealth);
        if (currentHealth < 1)
        {
            
            Button_do_thing("ded 0");
        }
    }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }


}