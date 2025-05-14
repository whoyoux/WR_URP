using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableItem : MonoBehaviour
{
    public Transform itemGOHolder;
    private Light lightUnderGO;

    public Item item;

    void Start()
    {
        lightUnderGO = GetComponentInChildren<Light>();

        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 1f).setLoopPingPong();
        LeanTween.rotateAround(gameObject, Vector3.up, 360f, 5f).setLoopClamp();
        LeanTween.moveY(gameObject, transform.position.y + 0.5f, 1f).setLoopPingPong();

        Instantiate(item.itemPrefab, itemGOHolder.position, Quaternion.identity, itemGOHolder);

        if (item.itemLight == Item.ItemLight.Red)
        {
            lightUnderGO.color = Color.red;
        }
        else if (item.itemLight == Item.ItemLight.Green)
        {
            lightUnderGO.color = Color.green;
        }
        else if (item.itemLight == Item.ItemLight.Blue)
        {
            lightUnderGO.color = Color.blue;
        }
        else if (item.itemLight == Item.ItemLight.Yellow)
        {
            lightUnderGO.color = Color.yellow;
        }
        else
        {
            lightUnderGO.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool isItemCollected = PlayerInventory.instance.CollectItem(item);
            if (isItemCollected)
                {
                    Destroy(gameObject);
                }
        }
    }
}
