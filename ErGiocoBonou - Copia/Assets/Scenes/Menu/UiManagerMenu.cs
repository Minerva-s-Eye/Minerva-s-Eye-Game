using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagerMenu : MonoBehaviour
{

    public GameObject menu;
    public GameObject extra;
    public GameObject minigiochi;


    public void Menu()
    {
        extra.SetActive(false);
        menu.SetActive(true);
    }


    public void Extra()
    {
        menu.SetActive(false);
        extra.SetActive(true);
        minigiochi.SetActive(false);
    }

    public void Minigiochi()
    {
        menu.SetActive(false);
        extra.SetActive(false);
        minigiochi.SetActive(true);
    }

}
