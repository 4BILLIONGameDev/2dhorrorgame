using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InventorySlotUi : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;

    public void UpdateSlot(ItemData item, int count)
    {
        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            countText.text = count > 1 ? count.ToString() : "";
        }
        else
        {
            icon.enabled = false;
            countText.text = "";
        }
    }
}