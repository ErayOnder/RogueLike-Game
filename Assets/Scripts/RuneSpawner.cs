using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuneSpawner : MonoBehaviour
{
    public HallManager hallManager;
    public GameObject runePrefab;

    private Tilemap objectsTilemap;
    private Vector3Int runePosition;

    public void PlaceRune()
    {
        objectsTilemap = hallManager.GetObjectTilemap();

        if (objectsTilemap == null)
        {
            Debug.LogError("No object tilemap found, cannot place rune");
            return;
        }

        List<Vector3Int> objectPositions = new();

        BoundsInt bounds = objectsTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (objectsTilemap.HasTile(pos))
            {
                objectPositions.Add(pos);
            }
        }

        if (objectPositions.Count > 0)
        {
            runePosition = objectPositions[Random.Range(0, objectPositions.Count)];
            Vector3 worldPosition = objectsTilemap.GetCellCenterWorld(runePosition);
            Instantiate(runePrefab, worldPosition, Quaternion.identity);
            Debug.Log("Rune placed at " + runePosition);
        } else
        {
            Debug.Log("No more positions to place runes, you win!");
        }
    }

    public Vector3Int GetRunePosition()
    {
        return runePosition;
    }

}