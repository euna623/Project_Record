using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationInterval = 3.0f; // 회전 간격 설정
    private float nextRotationTime; // 다음 회전 시간을 저장하는 변수

    void Start()
    {
        // 최초 회전 시간 초기화
        nextRotationTime = Time.time + rotationInterval;
    }

    void Update()
    {
        // 현재 시간이 다음 회전 시간을 넘어갈 경우
        if (Time.time >= nextRotationTime)
        {
            // 랜덤한 회전 각도 설정
            float randomAngle = Random.Range(0, 2) == 0 ? -90.0f : 90.0f;

            // 카메라 회전 적용
            transform.Rotate(Vector3.forward, randomAngle);

            // 다음 회전 시간 설정
            nextRotationTime = Time.time + rotationInterval;
        }
    }
}
