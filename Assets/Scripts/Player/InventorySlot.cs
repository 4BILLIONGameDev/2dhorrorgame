using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int count;

    public void AddItem(ItemData newItem)
    {
        if (item == newItem && item.isStackable)
            count++;
        else
        {
            item = newItem;
            count = 1;
        }
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}