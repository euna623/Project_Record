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
            // ���������� �̵�
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        // 5�� �Ŀ� ������Ʈ ����
        if (timer >= destroyDelay)
        {
            Destroy(gameObject);
        }
    }
}
