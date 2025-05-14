using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private List<Item> inventory = new();

    const int MAX_INVENTORY_SIZE = 5;

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

    void AddToInventory(Item item)
    {
        inventory.Add(item);

        Debug.Log("Adding item to inventory: " + item.itemName);
        CanvasManager.instance.RenderPlayerInventory();
    }

    public bool CollectItem(Item item)
    {
        Debug.Log("Collected item: " + item.itemName);

        switch(item.itemType)
        {
            case Item.ItemType.Coin:
                GameManager.instance.AddScore(1);
                CanvasManager.instance.RenderScore();
                return true;
            case Item.ItemType.Health:
                // Add health to player
                return true;
            case Item.ItemType.ToInventory:
                if (inventory.Count < MAX_INVENTORY_SIZE)
                {
                    AddToInventory(item);
                    return true;
                }
                else
                {
                    Debug.Log("Inventory is full!");
                    return false;
                }
                
            default:
                Debug.Log("Unknown item type: " + item.itemType);
                return false;
        }
    }

    public List<Item> GetInv()
    {
        return inventory;
    }
}
