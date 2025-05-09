using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Interactions : MonoBehaviour , IInteractable2D
{
    public ItemData itemData;

public void OnInteract()
{
    Debug.Log($"�÷��̾ {itemData.itemName} ��(��) �ֿ���!");
    Inventory.instance.AddItem(itemData);
    Destroy(gameObject); // �Ǵ� �κ��丮�� ���
}
}
