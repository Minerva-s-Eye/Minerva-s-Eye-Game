using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class otherScene3 : MonoBehaviour
{
    public void Button_do_thing(string nomeScena)
    {
        GameObject.FindGameObjectWithTag("Music9").GetComponent<MusicClass>().StopMusic();
        SceneManager.LoadScene(nomeScena);
    }


}
