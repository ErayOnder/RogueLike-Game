using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuneSpawner : MonoBehaviour
{
    public GameObject hallManager;
    public GameObject runePrefab;

    private Tilemap objectsTilemap;

    void Start()
    {
        ExtractObjectTilemap();
        PlaceRune();
    }

    private void ExtractObjectTilemap()
    {
        HallManager hallManagerScript = hallManager.GetComponent<HallManager>();
        GameObject currentHall = hallManagerScript.GetCurrentHall();
        if (currentHall != null)
        {
            objectsTilemap = currentHall.transform.Find("Grid/Objects").GetComponent<Tilemap>();
        } else
        {
            Debug.LogError("No current hall found, cannot extract object tilemap");
        }
    }

    private void PlaceRune()
    {
        if (objectsTilemap == null)
        {
            Debug.LogError("No object tilemap found, cannot place rune");
            return;
        }

        List<Vector3Int> objectPositions = new();
        BoundsInt bounds = objectsTilemap.cellBounds;
        
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            if (objectsTilemap.HasTile(position))
            {
                objectPositions.Add(position);
            }
        }

        if (objectPositions.Count > 0)
        {
            Vector3Int randomPosition = objectPositions[Random.Range(0, objectPositions.Count)];
            Vector3 worldPosition = objectsTilemap.GetCellCenterWorld(randomPosition);
            Instantiate(runePrefab, worldPosition, Quaternion.identity);
        } else
        {
            Debug.Log("No more positions to place runes, you win!");
        }
    }

}