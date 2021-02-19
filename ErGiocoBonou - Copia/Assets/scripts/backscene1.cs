using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backscene1 : MonoBehaviour
{
    

        public void Button_do_thing(string nomeScena)
        {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        SceneManager.LoadScene(nomeScena);
        }
    


}
