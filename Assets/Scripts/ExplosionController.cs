using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExplosionController : MonoBehaviour
{
    //public Tilemap tilemap;
    void Start()
    {
        var tilemap = FindObjectOfType<Tilemap>();

        var worldPosition = transform.position;
        var cellPosition = tilemap.WorldToCell(worldPosition);
        tilemap.SetTile(cellPosition, null);
        
        tilemap.SetTile(cellPosition + new Vector3Int(1, 0, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(1, 1, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(0, 1, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(-1, 1, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(-1, 0, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(-1, -1, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(0, -1, 0), null);
        tilemap.SetTile(cellPosition + new Vector3Int(1, -1, 0), null);
    }

    void Update()
    {
        
    }
}
