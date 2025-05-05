using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventorySlot> slots = new List<InventorySlot>();

    public ItemData TestItem;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);


        Add(TestItem);
    }

    public void Add(ItemData item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item && item.isStackable)
            {
                slot.count++;
                return;
            }
        }

        // ºó ½½·Ô Ã£±â
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}