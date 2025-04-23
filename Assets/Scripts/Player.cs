using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;



    private Rigidbody2D rigidbody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = InputManager.Instance.GetMovementInput().normalized;
        // ������ ó��
        dirDetermine(ref direction);
        if (InputManager.Instance.GetInteractPressed())
        {
            // �� ����, ������ �ݱ� ��
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = direction * moveSpeed;
    }

    void dirDetermine(ref Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > 0.1f && Mathf.Abs(dir.y) > 0.1f)
        {
            // ���⼱ ���� �켱 (x��)
            dir.y = 0f;
        }
    }
}
