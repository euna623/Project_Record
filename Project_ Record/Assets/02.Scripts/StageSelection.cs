using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelection : MonoBehaviour
{
    public GameObject targetObject;
    private Vector3 initialScale;

    private void Start()
    {
        // �ʱ� ������ ����
        initialScale = targetObject.transform.localScale;
    }

    private void Update()
    {
        // S Ű �Է� �� �����ϰ� ������ ����
        if (Input.GetKeyDown(KeyCode.S))
        {
            targetObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            targetObject.transform.position += new Vector3(0f, -130f, 0f);
        }

        // W Ű �Է� �� �����ϰ� ������ ����
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            targetObject.transform.position += new Vector3(0f, 130f, 0f);
        }
    }
}
