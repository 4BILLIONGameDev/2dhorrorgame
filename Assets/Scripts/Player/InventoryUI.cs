using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;  // ���� ������ ����
    public Transform slotParent;   // Grid Layout Group�� ���� ������Ʈ

    public int slotCount = 20;     // �κ��丮 ĭ ��
    private List<InventorySlotUi> slotUIs = new List<InventorySlotUi>();

    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent); // �ڵ����� ��ġ��
            InventorySlotUi slot = obj.GetComponent<InventorySlotUi>();
            slotUIs.Add(slot);

            // �ϴ� ����α�
            slot.UpdateSlot(null, 0);
        }
    }

    public void UpdateInventory(List<InventorySlot> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            slotUIs[i].UpdateSlot(data[i].item, data[i].count);
        }
    }
}
