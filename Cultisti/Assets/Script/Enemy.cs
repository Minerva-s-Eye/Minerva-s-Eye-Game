using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator anim;
    public float dazedTime;
    public float startDazedTime;
    public bool Finale;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (dazedTime <= 0)
        {

            speed = 2;

        }
        else
        {
            
            speed = 0;
            dazedTime -= Time.deltaTime;

        }


        if (health <= 0)
        {
            
        anim.SetTrigger("Death");
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+0.1f);

        }

        if (Finale)
        {
            if (health <= 0)
            {

                Time.timeScale = 0;

            }

        }

    }


    public void TakeDamage(int damage)
    {

            anim.SetTrigger("Colpito");
            dazedTime = startDazedTime;
            health -= damage;
        
    }

}

