using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvUISlot : MonoBehaviour
{
    public Image iconSlot;

    public void RenderItem(Item item)
    {
        if (item != null)
        {
            iconSlot.sprite = item.itemSprite;
            iconSlot.enabled = true;
        }
        else
        {
            iconSlot.enabled = false;
        }
    }
}
