using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnLocation;
    public CinemachineTargetGroup targetGroup;
    PlayerInputManager manager;
    int playerCount = 0;
    public TMP_Text winText;
    public bool winScreen;
    public float menuCountdown;
    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        //manager.DisableJoining();
        winText.enabled = false;
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        //Debug.Log(playerInput.gameObject);
        targetGroup.AddMember(playerInput.transform, 1.0f, 5.0f);
        playerInput.gameObject.transform.position = spawnLocation.position;
        playerInput.gameObject.name = "Player " + playerCount;
        playerCount += 1;
        if (playerCount >= 2)
        {
            manager.DisableJoining();
        }
    }
    void OnPlayerLeft(PlayerInput playerInput)
    {
        winText.enabled = true;
        winScreen = true;
        //Debug.Log("Player Has Left :(");
    }
    void Update()
    {
        if (winScreen)
        {
            if (menuCountdown <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
            menuCountdown -= Time.deltaTime;
        }
    }
}

