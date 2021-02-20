using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void OnPlay ()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void OnBack ()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnCredits ()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnQuit ()
    {
        Application.Quit();
    }
}
