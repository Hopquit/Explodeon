using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectController : MonoBehaviour
{
    public void OnSelect(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }
}
