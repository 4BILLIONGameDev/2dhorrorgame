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
                Debug.Log("박스 입니다");
                break;

            case "Door":
                Debug.Log("문 입니다");
                break;

            case "Trap":
                Debug.Log("덫 발동!");
                break;

            default:
                Debug.Log("알 수 없는 오브젝트...");
                break;
        }
    }
}
