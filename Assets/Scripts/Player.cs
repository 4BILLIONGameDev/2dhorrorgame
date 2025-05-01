using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float blockSize = 1f;  // �� ũ�� (1ĭ)

    private IInteractable2D currentInteractTarget = null;
    private Rigidbody2D rigidbody;
    private Vector2 inputDirection;
    private Animator animator;
    private bool isMoving = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("MoveSpeed", inputDirection.sqrMagnitude);


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
            interact();
        }
    }

    IEnumerator MoveByBlock(Vector2 moveDirection)
    {
        if (moveDirection.x > 0)
        {
            //�������̵�
            animator.SetInteger("Direction", 3);
        }
        else if (moveDirection.x < 0)
        {
            //�����̵�
            animator.SetInteger("Direction", 2);
        }
        else if (moveDirection.y > 0)
        {
            //�����̵�
        }
        else if (moveDirection.y < 0)
        {
            //�Ʒ��̵�
            animator.SetInteger("Direction", 1);
        }
        isMoving = true;

        Vector2 startPos = rigidbody.position;
        Vector2 targetPos = startPos + moveDirection * blockSize;

        float elapsedTime = 0f;
        float moveDuration = blockSize / moveSpeed;  // �� �ϳ� �̵��ϴ� �� �ɸ��� �ð�
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        rigidbody.MoveRotation(angle - 90f);
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
        var interactable = other.GetComponent<IInteractable2D>();
        if (interactable != null)
        {
            currentInteractTarget = interactable;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable2D>();
        if (interactable != null && interactable == currentInteractTarget)
        {
            currentInteractTarget = null;
        }
    }

    void interact()
    {


        Vector2 lookDirection = transform.right.normalized; // �Ӹ� ���� ����
        Vector2 center = (Vector2)transform.position + lookDirection * 1.2f;

        Collider2D hit = Physics2D.OverlapCircle(center, 0.5f); // ������ 0.5 ����

        Debug.DrawLine(transform.position, center, Color.green, 0.2f);
        Debug.DrawRay(center, Vector2.up * 0.1f, Color.cyan, 0.2f); // �˻� �߽� ǥ��

        if (hit != null)
        {
            var interactable = hit.GetComponent<IInteractable2D>();
            if (interactable != null)
            {
                interactable.OnInteract();
                Debug.Log("���ͷ��� ����: " + hit.name);
            }
            else
            {
                Debug.Log("�������̽� ����: " + hit.name);
            }
        }
        else
        {
            Debug.Log("�տ� �ƹ��͵� ����~");
        }
    }
}
