﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void OnPlay ()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void OnQuit ()
    {
        Application.Quit();
    }
}
