using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownObject : MonoBehaviour, IInteractable2D
{
    public void OnInteract()
    {
        switch (tag)
        {
            case "Box":
                Debug.Log("�ڽ� �Դϴ�");
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
