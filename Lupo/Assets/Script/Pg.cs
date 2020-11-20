using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pg : MonoBehaviour
{

    public int  maxHealth = 10000;
    public int currentHealth;
    public int vitaPersa = 1;


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

        currentHealth -= vitaPersa;
        healthBar.SetHealth(currentHealth);

    }



    public void Heal(int damage)
    {

        currentHealth += 500;

        healthBar.SetHealth(currentHealth);

    }


}