using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float destroyDelay = 5.0f;

    private float timer = 0.0f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            // 오른쪽으로 이동
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        // 5초 후에 오브젝트 삭제
        if (timer >= destroyDelay)
        {
            Destroy(gameObject);
        }
    }
}
