using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform player;  
    public float moveSpeed = 3f;  // 이동 속도
    public float blockSize = 1f; // 한 번에 이동할 거리 (블럭 크기)

    private Rigidbody2D rb;  
    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isMoving && player != null)
        {
            Vector2 direction = (player.position - transform.position);

            Vector2 moveDirection;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                moveDirection = new Vector2(Mathf.Sign(direction.x), 0f);
            }
            else
            {
                moveDirection = new Vector2(0f, Mathf.Sign(direction.y));
            }

            StartCoroutine(MoveByBlock(moveDirection));
        }
    }

    private IEnumerator MoveByBlock(Vector2 moveDirection)
    {
        isMoving = true;

        Vector2 startPos = rb.position;
        Vector2 targetPos = startPos + moveDirection * blockSize;

        float elapsedTime = 0f;
        float moveDuration = blockSize / moveSpeed; // 이동하는 데 걸리는 시간

        while (elapsedTime < moveDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration));
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(targetPos); // 마지막 위치 딱 맞추기
        isMoving = false;
    }
}
