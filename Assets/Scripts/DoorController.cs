using System.Numerics;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile openDoorTile;
    private Vector3Int doorPosition = new(1, -8, 0);
    private bool isLocked = true;

    [ContextMenu("Unlock Door")]
    public void Unlock()
    {
        if (isLocked)
        {
            isLocked = false;
            tilemap.SetTile(doorPosition, openDoorTile);
            GetComponent<TilemapCollider2D>().enabled = false;
            Debug.Log("Door unlocked!");
        }
        else
        {
            Debug.Log("Door is already unlocked!");
        }
    }

    public bool IsLocked()
    {
        return isLocked;
    }
    
}