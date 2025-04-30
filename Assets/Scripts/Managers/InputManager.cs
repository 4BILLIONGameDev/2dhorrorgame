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
        // 마우스 왼쪽 클릭
        return Input.GetMouseButtonDown(0);
    }
    public Vector2 GetMovementInput()
    {
        //상하 좌우 이동
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool GetInteractPressed()
    {
        //E키 상호작용
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool GetObserverSwitch()
    {
        //탭 키 상호작용
        return Input.GetKeyDown(KeyCode.Tab); 
    }
}
