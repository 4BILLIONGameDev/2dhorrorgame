using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public ItemData testItem; // <- Inspector���� ���� �׽�Ʈ�� ScriptableObject
    void Start()
    {
        Inventory.instance.Add(testItem);  // ������ 1�� �߰�

        Inventory.instance.Add(testItem); // ������ 1�� �߰�
    }
}
