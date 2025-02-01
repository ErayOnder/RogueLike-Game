using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private HallManager hallManager;

    void Start()
    {
        hallManager = FindFirstObjectByType<HallManager>();
        if (hallManager == null)
        {
            Debug.LogError("DoorTrigger: No HallManager found in the scene!");
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            Debug.Log("Player walked through the door! Loading next hall...");
            hallManager.LoadNextHall();
        }
    }
}
