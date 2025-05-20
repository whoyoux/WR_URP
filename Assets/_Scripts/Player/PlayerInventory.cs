using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    private List<Item> inventory = new();

    const int MAX_INVENTORY_SIZE = 5;

    // Singleton pattern
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void AddToInventory(Item item)
    {
        inventory.Add(item);

        Debug.Log("Adding item to inventory: " + item.itemName);
        CanvasManager.instance.RenderPlayerInventory();
    }

    public bool CollectItem(Item item)
    {
        // Obs³uga ró¿nych typów przedmiotów na podstawie typu
        switch (item.itemType)
        {
            case Item.ItemType.Coin:
                // Moneta zwiêksza wynik
                GameManager.instance.AddScore(1);
                CanvasManager.instance.RenderCoinsText();
                return true;
            case Item.ItemType.Health:
                // Leczenie gracza
                GameManager.instance.AddHealth(10);
                return true;
            case Item.ItemType.ToInventory:
                // Przedmiot dodawany do ekwipunku, o ile nie jest pe³ny
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
