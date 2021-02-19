using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestraSinistra : MonoBehaviour //Script stupido che fa muovere la piattaforma su e giu in manier
{
    private float useSpeed;
    public float directionSpeed;
    float origX;
    public float distance = 10.0f;

    // Use this for initialization
    void Start()
    {
       
        origX = transform.position.x;
        useSpeed = -directionSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /* if (fermete)
        {
            useSpeed = 0;
            directionSpeed = 0;
        }*/
         if (origX - transform.position.x > distance)
        {
            useSpeed = directionSpeed; //flip direction
        }
        else if (origX - transform.position.x < -distance)
        {
            useSpeed = -directionSpeed; //flip direction
        }
        transform.Translate(useSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            this.useSpeed = 0;
            this.directionSpeed = 0;
        }
    }
}
