using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    private bool rotatingLeft = false;
    private bool rotatingRight = false;

    private float originalRotationSpeed; // ������ ȸ�� �ӵ��� �����ϴ� ����

    private void Start()
    {
        originalRotationSpeed = rotationSpeed; // ������ ȸ�� �ӵ��� ����
    }

    void Update()
    {
        // Q Ű�� ������ �������� ��� ȸ��
        if (Input.GetKey(KeyCode.Q))
        {
            rotatingLeft = true;
            rotatingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && rotationSpeed == originalRotationSpeed) // �� �����ٸ�
        {
            rotationSpeed *= 3.0f; // ���� �ӵ��� 3��� ����
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            rotationSpeed = originalRotationSpeed; // �ӵ��� ������� ����
            rotatingLeft = true;
            rotatingRight = false;
        }

        // E Ű�� ������ ���������� ��� ȸ��
        if (Input.GetKey(KeyCode.E))
        {
            rotatingRight = true;
            rotatingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && rotationSpeed == originalRotationSpeed) // �� �����ٸ�
        {
            rotationSpeed *= 3.0f; // ���� �ӵ��� 3��� ����
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            rotationSpeed = originalRotationSpeed; // �ӵ��� ������� ����
            rotatingRight = true;
            rotatingLeft = false;
        }

        // ȸ�� ó��
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
        // ȸ�� ���� ���
        float rotationAngle = Time.deltaTime * rotationSpeed * direction;

        // Y�� ȸ�� ����
        transform.Rotate(Vector3.up, rotationAngle);
    }
}