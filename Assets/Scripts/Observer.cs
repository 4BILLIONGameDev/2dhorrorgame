using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    public float interactionDistance = 5f;

    void Update()
    {
        if (InputManager.Instance.GetMouseClick()) // ��Ŭ��
        {
            interact();
        }
    }
    void interact()
    {
        Vector2 clickPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject target = hit.collider.gameObject;


            Debug.Log("Ŭ���� ������Ʈ: " + target.tag);

            var interactable = target.GetComponent<IInteractable2D>();
            if (interactable != null)
                interactable.OnInteract();

        }
    }
}
