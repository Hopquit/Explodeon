using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Destructability : MonoBehaviour
{
    Tilemap tilemap;
    Vector2 cursorPosition;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.press.wasPressedThisFrame)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            tilemap.SetTile(tilemap.WorldToCell(worldPosition), null);
        }
    }
   
}
