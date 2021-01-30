using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;
    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log(playerInput.gameObject);
        targetGroup.AddMember(playerInput.transform, 1.0f, 5.0f);
    }

}

