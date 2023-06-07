using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationDuration = 1.0f; // 회전 시간
    public float rotationInterval = 2.0f; // 회전 간격

    private Quaternion initialRotation; // 초기 회전값
    private Coroutine rotationCoroutine; // 회전 코루틴

    private void Start()
    {
        // 초기 회전값 저장
        initialRotation = transform.rotation;

        // 회전 코루틴 시작
        rotationCoroutine = StartCoroutine(PerformRotation());
    }

    private IEnumerator PerformRotation()
    {
        while (true)
        {
            // 회전 각도를 랜덤하게 결정
            float rotationAmount = GetRandomRotationAmount();
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotationAmount));

            // 회전 시간동안 서서히 회전
            float elapsedTime = 0f;
            while (elapsedTime < rotationDuration)
            {
                transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 회전이 끝나면 초기 회전값 갱신
            initialRotation = transform.rotation;

            // 회전 간격만큼 대기
            yield return new WaitForSeconds(rotationInterval);
        }
    }

    private float GetRandomRotationAmount()
    {
        int randomIndex = Random.Range(0, 5);
        float[] rotationAmounts = { 90f, -90f, 180f, -180f , 0f };
        //Debug.Log(rotationAmounts[randomIndex] + "만큼 회전");
        return rotationAmounts[randomIndex];
    }
}
