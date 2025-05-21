using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]


public class Item : ScriptableObject
{
    public enum ItemType
    {
        Coin,
        Health,
        ToInventory,
        Damage,
    }

    public enum ItemLight
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    public string itemName;
    public string itemID;
    public ItemType itemType = ItemType.ToInventory;
    public ItemLight itemLight = ItemLight.Red;

    public Sprite itemSprite;
    public GameObject itemPrefab;
    public AudioClip itemAudioClip;
}
