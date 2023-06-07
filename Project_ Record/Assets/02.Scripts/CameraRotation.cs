using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationDuration = 1.0f; // ȸ�� �ð�
    public float rotationInterval = 2.0f; // ȸ�� ����

    private Quaternion initialRotation; // �ʱ� ȸ����
    private Coroutine rotationCoroutine; // ȸ�� �ڷ�ƾ

    private void Start()
    {
        // �ʱ� ȸ���� ����
        initialRotation = transform.rotation;

        // ȸ�� �ڷ�ƾ ����
        rotationCoroutine = StartCoroutine(PerformRotation());
    }

    private IEnumerator PerformRotation()
    {
        while (true)
        {
            // ȸ�� ������ �����ϰ� ����
            float rotationAmount = GetRandomRotationAmount();
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, rotationAmount));

            // ȸ�� �ð����� ������ ȸ��
            float elapsedTime = 0f;
            while (elapsedTime < rotationDuration)
            {
                transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / rotationDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // ȸ���� ������ �ʱ� ȸ���� ����
            initialRotation = transform.rotation;

            // ȸ�� ���ݸ�ŭ ���
            yield return new WaitForSeconds(rotationInterval);
        }
    }

    private float GetRandomRotationAmount()
    {
        int randomIndex = Random.Range(0, 5);
        float[] rotationAmounts = { 90f, -90f, 180f, -180f , 0f };
        //Debug.Log(rotationAmounts[randomIndex] + "��ŭ ȸ��");
        return rotationAmounts[randomIndex];
    }
}
