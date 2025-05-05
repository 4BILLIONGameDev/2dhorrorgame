using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject slotPrefab;  // 슬롯 프리팹 연결
    public Transform slotParent;   // Grid Layout Group이 붙은 오브젝트

    public int slotCount = 20;     // 인벤토리 칸 수
    private List<InventorySlotUi> slotUIs = new List<InventorySlotUi>();

    void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent); // 자동으로 배치됨
            InventorySlotUi slot = obj.GetComponent<InventorySlotUi>();
            slotUIs.Add(slot);

            // 일단 비워두기
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
