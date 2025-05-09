using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<ItemData> items = new List<ItemData>();

    public event Action<ItemData> OnItemAdded; // <- UI에 알리는 이벤트

    void Awake()
    {
        instance = this;
    }

    public void AddItem(ItemData newItem)
    {
        items.Add(newItem);
        OnItemAdded?.Invoke(newItem); // UI에게 알림 보내기
    }
}