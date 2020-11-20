using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUN : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isRunning", false);
        }

    }


    public void Corsa()
    {
            
        anim.SetBool("isRunning", true);

    }


}
