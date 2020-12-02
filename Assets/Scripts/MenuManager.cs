using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject beatMenu;
    public GameObject optionsMenu;

    // i'm not sure there's a good way to do this, oh well!
    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }


    public void OpenBeat()
    {
        beatMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseBeat()
    {
        beatMenu.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void OpenMenu()
    {
        mainMenu.SetActive(true);
    }
    public void CloseMenu()
    {
        mainMenu.SetActive(false);
    }
}
