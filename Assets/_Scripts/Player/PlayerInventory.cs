using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CollectItem(Item item)
    {
        // Add item to inventory
        // You can use a List<Item> or Dictionary<string, Item> to store items
        // For example:
        // inventory.Add(item);
        Debug.Log("Collected item: " + item.itemName);

        return true;
    }
}
