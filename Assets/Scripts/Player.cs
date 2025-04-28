using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float blockSize = 1f;  // �� ũ�� (1ĭ)

    private GameObject currentTarget = null;
    private Rigidbody2D rigidbody;
    private Vector2 inputDirection;
    private bool isMoving = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isMoving)
        {
            inputDirection = InputManager.Instance.GetMovementInput().normalized;
            dirDetermine(ref inputDirection);

            if (inputDirection != Vector2.zero)
            {
                StartCoroutine(MoveByBlock(inputDirection));
            }
        }

        if (InputManager.Instance.GetInteractPressed())
        {
            if (currentTarget != null)
                interact(currentTarget);
        }
    }

    IEnumerator MoveByBlock(Vector2 moveDirection)
    {
        isMoving = true;

        Vector2 startPos = rigidbody.position;
        Vector2 targetPos = startPos + moveDirection * blockSize;

        float elapsedTime = 0f;
        float moveDuration = blockSize / moveSpeed;  // �� �ϳ� �̵��ϴ� �� �ɸ��� �ð�

        while (elapsedTime < moveDuration)
        {
            rigidbody.MovePosition(Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration));
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rigidbody.MovePosition(targetPos); // ������ ��ġ �� ���߱�
        isMoving = false;
    }

    void dirDetermine(ref Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > 0.1f && Mathf.Abs(dir.y) > 0.1f)
        {
            dir.y = 0f; // ���� �켱
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentTarget = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentTarget = null;
    }

    void interact(GameObject Object)
    {
        if (Object.CompareTag("Box"))
            Destroy(Object);
    }
}
