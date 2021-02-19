using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    public bool Ij;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Health = 1;
        Ij = false;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.Space)|| Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began) && Ij == false) {

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 6, 0);

            Ij = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Ij = false;


        if (collision.gameObject.name == "GameOverZone1"|| collision.gameObject.name == "GameOverZone2") {
            Health = Health - 1; 
        }

        if (Health <= 0)
        {
            Button_do_thing("ded 1");

        }  
        
        if (collision.gameObject.name == "Win") {
            Button_do_thing("nero 1");
        }

        

    }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }


}
