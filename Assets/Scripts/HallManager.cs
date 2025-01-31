using UnityEngine;
using UnityEngine.Tilemaps;

public class HallManager : MonoBehaviour
{
    public GameObject[] halls;
    public int currentHallIndex = 0;
    private GameObject currentHall;

    public GameObject hero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadHall(currentHallIndex);
    }

    public void LoadNextHall()
    {
        if (currentHallIndex < halls.Length - 1)
        {
            currentHallIndex++;
            LoadHall(currentHallIndex);
        } else
        {
            Debug.Log("No more halls to load, you win!");
        }
    }


    private void LoadHall(int hallIndex)
    {
        if (currentHall != null)
        {
            Destroy(currentHall);
        }

        currentHall = Instantiate(halls[hallIndex], Vector3.zero, Quaternion.identity);
        hero.transform.position = new Vector3(0, 0, 0);

        FindFirstObjectByType<RuneSpawner>().PlaceRune();
    }

    public GameObject GetCurrentHall()
    {
        return currentHall;
    }

    public Tilemap GetObjectTilemap()
    {
        if (currentHall != null)
        {
            return currentHall.transform.Find("Grid/Objects").GetComponent<Tilemap>();
        } else
        {
            Debug.LogError("No current hall found, cannot extract object tilemap");
            return null;
        }
    }

}