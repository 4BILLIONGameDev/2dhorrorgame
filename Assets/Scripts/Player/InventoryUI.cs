using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] slots;

    void Start()
    {
        Inventory.instance.OnItemAdded += AddItemToUI;
        inventoryClear();
    }

    void AddItemToUI(ItemData item)
    {
        foreach (var slot in slots)
        {
            if (!slot.icon.enabled) // ∫ÒæÓ¿÷¥¬ ΩΩ∑‘¿Ã∏È
            {
                Debug.Log("»πµÊ æ∆¿Ã≈€:");
                Debug.Log(item.name);
                slot.SetItem(item.icon,item.description);
                break;
            }
        }
    }

    void inventoryClear()
    {
        foreach (var slot in slots)
        {
            slot.Clear();
        }
    }
}
