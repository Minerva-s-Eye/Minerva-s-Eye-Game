using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backscene : MonoBehaviour
{
    

        public void Button_do_thing(string nomeScena)
        {
            SceneManager.LoadScene(nomeScena);
        }
    


}
