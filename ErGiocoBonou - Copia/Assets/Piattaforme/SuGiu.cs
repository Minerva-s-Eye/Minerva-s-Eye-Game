using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuGiu : MonoBehaviour //Script stupido che fa muovere la piattaforma su e giu in manier
{
    private float useSpeed;
    public float directionSpeed;
    float origY;
    Animator esplosione;
    public float distance = 10.0f;

    // Use this for initialization
    void Start()
    {
        esplosione = GetComponent<Animator>();
        origY = transform.position.y;
        useSpeed = -directionSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (origY - transform.position.y > distance)
        {
            useSpeed = directionSpeed; //flip direction
        }
        else if (origY - transform.position.y < -distance)
        {
            useSpeed = -directionSpeed; //flip direction
        }
        transform.Translate(0, useSpeed * Time.deltaTime, 0);
    }
}
