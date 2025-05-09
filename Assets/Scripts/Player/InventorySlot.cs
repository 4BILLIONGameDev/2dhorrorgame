using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public string description;

    public void SetItem(Sprite itemIcon, string itemDescription)
    {
        icon.sprite = itemIcon;
        icon.enabled = true;
        description = itemDescription;

    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipUi.instance.ShowTooltip(description, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipUi.instance.HideTooltip();
    }
}