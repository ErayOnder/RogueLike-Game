using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject[] hallPrefabs;
    public Transform hallParent;
    public Text selectedObjectText;
    public Button[] objectButtons;
    public Text messageText;

    private GameObject selectedHall;
    private Dictionary<string, int> hallObjectLimits = new Dictionary<string, int>
    {
        { "Hall_Earth", 6 },
        { "Hall_Air", 9 },
        { "Hall_Water", 13 },
        { "Hall_Fire", 17 }
    };
    private Dictionary<string, List<GameObject>> placedObjects = new Dictionary<string, List<GameObject>>();

    void Start()
    {
        foreach (var button in objectButtons)
        {
            string objectType = button.name;
            button.onClick.AddListener(() => SelectObject(button.name));
        }
    }

    void Update()
    {
        
    }

    void SelectObject(string objectType)
    {
        if (selectedHall != null)
        {
            Destroy(selectedHall);
        }

        selectedHall = Instantiate(hallPrefabs[0], Vector3.zero, Quaternion.identity);
        selectedObjectText.text = objectType;
    }
    
}
