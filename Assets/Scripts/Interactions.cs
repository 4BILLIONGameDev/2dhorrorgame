using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Interactions : MonoBehaviour , IInteractable2D
{
    public ItemData itemData;

public void OnInteract()
{
    Debug.Log($"플레이어가 {itemData.itemName} 을(를) 주웠다!");
    Inventory.instance.AddItem(itemData);
    Destroy(gameObject); // 또는 인벤토리에 등록
}
}
