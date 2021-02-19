using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class otherScene2 : MonoBehaviour
{
    public void Button_do_thing(string nomeScena)
    {
        GameObject.FindGameObjectWithTag("Music6").GetComponent<MusicClass>().StopMusic();
        SceneManager.LoadScene(nomeScena);
    }


}
