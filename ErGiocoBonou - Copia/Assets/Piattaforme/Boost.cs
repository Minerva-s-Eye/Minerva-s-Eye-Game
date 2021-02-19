using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float useSpeed;
    public float directionSpeed;
    float origY;
    public float distance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        origY = transform.position.x;
        useSpeed = -directionSpeed;
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
            gameObject.SetActive(false); //sparisci

        }
    }
}
