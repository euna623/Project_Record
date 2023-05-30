using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationInterval = 3.0f; // ȸ�� ���� ����
    private float nextRotationTime; // ���� ȸ�� �ð��� �����ϴ� ����

    void Start()
    {
        // ���� ȸ�� �ð� �ʱ�ȭ
        nextRotationTime = Time.time + rotationInterval;
    }

    void Update()
    {
        // ���� �ð��� ���� ȸ�� �ð��� �Ѿ ���
        if (Time.time >= nextRotationTime)
        {
            // ������ ȸ�� ���� ����
            float randomAngle = Random.Range(0, 2) == 0 ? -90.0f : 90.0f;

            // ī�޶� ȸ�� ����
            transform.Rotate(Vector3.forward, randomAngle);

            // ���� ȸ�� �ð� ����
            nextRotationTime = Time.time + rotationInterval;
        }
    }
}
