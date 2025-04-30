using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool GetMouseClick()
    {
        // ���콺 ���� Ŭ��
        return Input.GetMouseButtonDown(0);
    }
    public Vector2 GetMovementInput()
    {
        //���� �¿� �̵�
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool GetInteractPressed()
    {
        //EŰ ��ȣ�ۿ�
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool GetObserverSwitch()
    {
        //�� Ű ��ȣ�ۿ�
        return Input.GetKeyDown(KeyCode.Tab); 
    }
}
