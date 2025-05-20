using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public ItemData testItem; // <- Inspector에서 넣을 테스트용 ScriptableObject
    void Start()
    {
        Inventory.instance.Add(testItem);  // 아이템 1개 추가

        Inventory.instance.Add(testItem); // 아이템 1개 추가
    }
}
