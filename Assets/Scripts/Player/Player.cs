using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float blockSize = 1f;  // 블럭 크기 (1칸)
    public GameObject inventoryUI;

    private IInteractable2D currentInteractTarget = null;
    private Rigidbody2D rigidbody;


    private Vector2 inputDirection;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool isMoving = false;
    Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = Quaternion.identity;
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = transform.Find("Fixed").GetComponent<BoxCollider2D>();
        animator = transform.Find("Fixed").GetComponent<Animator>();
        inventoryUI.SetActive(false);


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

        if (InputManager.Instance.GetInventoryPressed())
        {
            inventoryShow();
        }

    }
    void LateUpdate()
    {
        
    }
    IEnumerator MoveByBlock(Vector2 moveDirection)
    {
        if (moveDirection.x > 0)
        {
            //오른쪽이동
            animator.SetInteger("Direction", 3);
        }
        else if (moveDirection.x < 0)
        {
            //왼쪽이동
            animator.SetInteger("Direction", 2);
        }
        else if (moveDirection.y > 0)
        {
            //위쪽이동
            animator.SetInteger("Direction", 4);
        }
        else if (moveDirection.y < 0)
        {
            //아래이동
            animator.SetInteger("Direction", 1);
        }
        isMoving = true;

        Vector2 startPos = rigidbody.position;
        Vector2 targetPos = startPos + moveDirection * blockSize;

        float elapsedTime = 0f;
        float moveDuration = blockSize / moveSpeed;  // 블럭 하나 이동하는 데 걸리는 시간
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        rigidbody.MoveRotation(angle - 90f);
        while (elapsedTime < moveDuration)
        {
            rigidbody.MovePosition(Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration));
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rigidbody.MovePosition(targetPos); // 마지막 위치 딱 맞추기
        isMoving = false;
    }

    void dirDetermine(ref Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > 0.1f && Mathf.Abs(dir.y) > 0.1f)
        {
            dir.y = 0f; // 가로 우선
        }
       

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactions>();
        Debug.Log(interactable);
        if (interactable != null)
        {
            currentInteractTarget = interactable;
            Debug.Log(currentInteractTarget + "타겟 설정");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<Interactions>();
        Debug.Log("벗어남");
        if (interactable != null)
        {
            currentInteractTarget = null;
        }
    }

    void interact()
    {

        if (currentInteractTarget != null)
        {
            currentInteractTarget.OnInteract();
           //ug.Log("인터랙션 성공: " + hit.name);
        }
        else
        {
          //Debug.Log("인터페이스 없음: " + hit.name);
        }
    }

    void inventoryShow()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
