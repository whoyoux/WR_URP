using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableItem : MonoBehaviour
{
    public Transform itemGOHolder;

    public Item item;

    void Start()
    {
        LeanTween.moveY(gameObject, transform.position.y + 0.5f, 1f).setLoopPingPong();
        Instantiate(item.itemPrefab, itemGOHolder.position, Quaternion.identity, itemGOHolder);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool isItemCollected = PlayerInventory.instance.CollectItem(item);
            if(isItemCollected)
            {
                Destroy(gameObject);
            }
        }
    }
}
