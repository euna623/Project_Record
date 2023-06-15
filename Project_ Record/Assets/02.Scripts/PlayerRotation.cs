using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    private bool rotatingLeft = false;
    private bool rotatingRight = false;

    private float originalRotationSpeed; // 원래의 회전 속도를 저장하는 변수

    private void Start()
    {
        originalRotationSpeed = rotationSpeed; // 원래의 회전 속도를 저장
    }

    void Update()
    {
        // Q 키를 누르면 왼쪽으로 계속 회전
        if (Input.GetKey(KeyCode.Q))
        {
            rotatingLeft = true;
            rotatingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && rotationSpeed == originalRotationSpeed) // 꾹 눌렀다면
        {
            rotationSpeed *= 3.0f; // 기존 속도의 3배로 증가
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            rotationSpeed = originalRotationSpeed; // 속도를 원래대로 복구
            rotatingLeft = true;
            rotatingRight = false;
        }

        // E 키를 누르면 오른쪽으로 계속 회전
        if (Input.GetKey(KeyCode.E))
        {
            rotatingRight = true;
            rotatingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && rotationSpeed == originalRotationSpeed) // 꾹 눌렀다면
        {
            rotationSpeed *= 3.0f; // 기존 속도의 3배로 증가
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            rotationSpeed = originalRotationSpeed; // 속도를 원래대로 복구
            rotatingRight = true;
            rotatingLeft = false;
        }

        // 회전 처리
        if (rotatingLeft)
        {
            RotatePlayer(-1);
        }
        else if (rotatingRight)
        {
            RotatePlayer(1);
        }
    }

    void RotatePlayer(int direction)
    {
        // 회전 각도 계산
        float rotationAngle = Time.deltaTime * rotationSpeed * direction;

        // Y축 회전 적용
        transform.Rotate(Vector3.up, rotationAngle);
    }
}