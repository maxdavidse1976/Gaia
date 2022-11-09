using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryItem(string inventoryName, Sprite image)
    {
        inventory.Add(inventoryName, image);
    }

    public void RemoveInventoryItem(string inventoryName)
    {
        inventory.Remove(inventoryName);
    }

}
