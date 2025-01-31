using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickableObjects : MonoBehaviour
{
    public HallManager hallManager;
    public GameObject hero;

    private Tilemap objectsTilemap;

    void Update()
    {
        objectsTilemap = hallManager.GetObjectTilemap();

        if (objectsTilemap == null)
        {
            Debug.LogError("No object tilemap found, cannot place rune");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePosition = objectsTilemap.WorldToCell(mouseWorldPosition);

            if (objectsTilemap.HasTile(tilePosition) && IsHeroAdjacent(tilePosition))
            {
                Debug.Log("Clicked on object tile at " + tilePosition);
                HandleObjectClick(tilePosition);
            }
        }
    }

    private bool IsHeroAdjacent(Vector3Int tilePosition)
    {
        Vector3Int heroTilePosition = objectsTilemap.WorldToCell(hero.transform.position);
        return Vector3Int.Distance(tilePosition, heroTilePosition) <= 1;
    }

    private void HandleObjectClick(Vector3Int tilePosition)
    {
        if (tilePosition == FindFirstObjectByType<RuneSpawner>().GetRunePosition())
        {
            Debug.Log("Rune found, unlocking next hall");
            hallManager.LoadNextHall();
        } else
        {
            Debug.Log("No rune found at " + tilePosition);
            return;
        }
    }
}
