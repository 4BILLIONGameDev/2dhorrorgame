using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsObject : MonoBehaviour, IInteractable2D
{
    public void OnInteract()
    {
        switch (tag)
        {
            case "Monitor":
                Debug.Log("����� �Դϴ�");
                break;

            case "Door":
                Debug.Log("�� �Դϴ�");
                break;

            case "Trap":
                Debug.Log("�� �ߵ�!");
                break;

            default:
                Debug.Log("�� �� ���� ������Ʈ...");
                break;
        }
    }
}
