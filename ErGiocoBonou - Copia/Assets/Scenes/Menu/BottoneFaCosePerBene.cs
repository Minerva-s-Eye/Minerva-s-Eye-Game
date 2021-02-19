using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottoneFaCosePerBene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }

     
}
