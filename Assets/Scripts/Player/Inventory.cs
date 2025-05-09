using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<ItemData> items = new List<ItemData>();

    public event Action<ItemData> OnItemAdded; // <- UI�� �˸��� �̺�Ʈ

    void Awake()
    {
        instance = this;
    }

    public void AddItem(ItemData newItem)
    {
        items.Add(newItem);
        OnItemAdded?.Invoke(newItem); // UI���� �˸� ������
    }
}