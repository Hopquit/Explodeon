using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnLocation;
    public CinemachineTargetGroup targetGroup;
    PlayerInputManager manager;
    int playerCount = 0;
    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        //manager.DisableJoining();
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log(playerInput.gameObject);
        targetGroup.AddMember(playerInput.transform, 1.0f, 5.0f);
        playerInput.gameObject.transform.position = spawnLocation.position;
        playerCount += 1;
        if (playerCount >= 2)
        {
            manager.DisableJoining();
        }
    }

}

