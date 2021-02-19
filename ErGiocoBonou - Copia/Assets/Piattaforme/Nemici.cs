using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemici : MonoBehaviour
{
    private float useSpeed;
    public float directionSpeed;
    float origY;
    Animator esplosione;
    public float distance = 10.0f;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        esplosione = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        origY = transform.position.x;
        useSpeed = -directionSpeed;
        //rb.mass = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (origY - transform.position.x > distance)
        {
            useSpeed = directionSpeed; //flip direction
        }
        else if (origY - transform.position.x < -distance)
        {
            useSpeed = -directionSpeed; //flip direction
        }
        transform.Translate(useSpeed * Time.deltaTime, 0, 0);




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.directionSpeed = 0;
            this.useSpeed = 0;
            esplosione.SetTrigger("collide");
            // StartCoroutine("AttendiSparisci");
            Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.1f);

        }



    }
    IEnumerator AttendiSparisci()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false); //sparisci
    }
}