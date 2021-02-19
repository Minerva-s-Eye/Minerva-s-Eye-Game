using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music7").GetComponent<MusicClass>().StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (Health <= 0)
        {
            GameObject.FindGameObjectWithTag("Music9").GetComponent<MusicClass>().StopMusic();
            Button_do_thing("ded 11");

        }

    }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }
}
