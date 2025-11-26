using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Main Screne");
    }
    public void optionscrene()
    {
        SceneManager.LoadSceneAsync("Option Screne");

    }
    public void mainscrene()
    {
        SceneManager.LoadSceneAsync("Home Screne");

    }
    
}
