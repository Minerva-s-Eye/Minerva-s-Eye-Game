
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    private float movement = 0f;
    public float speed = 5f;
    private Rigidbody2D rigidBody;
    Vector3 characterScale;

    // Start is called before the first frame update
    void Start()
    {
   
        rb = GetComponent<Rigidbody2D>();
        rigidBody = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    { 
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX*3, 0);

    // Move
    movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {

            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(0.1483552f, 0.1483552f);
            
            
        }
        else if (movement < 0f)
        {

            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            transform.Rotate(Vector2.up * 180);

        }

    }

    public void Flip() {

                transform.Rotate(Vector2.up * 180);
    }

}
