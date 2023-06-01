using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public Material collidedMaterial; // �浹 �� ������ ���׸���

    private bool startCollided = false;
    private bool exitCollided = false;

    private Material originalMaterial; // ������ ���׸���

    void Start()
    {
        // ������Ʈ�� ���� ���׸��� ����
        originalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Space Ű�� ������ �� �� ��ȯ
        if (startCollided && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        else if (exitCollided && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("������");
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Start"))
        {
            Debug.Log("��ŸƮ �浹");
            startCollided = true;
            exitCollided = false;

            // �浹 �� ���׸��� ����
            GetComponent<Renderer>().material = collidedMaterial;
        }
        else if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("����Ʈ �浹");
            exitCollided = true;
            startCollided = false;

            // �浹 �� ���׸��� ����
            GetComponent<Renderer>().material = collidedMaterial;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Start") || collider.gameObject.CompareTag("Exit"))
        {
            // �浹 ���� �� ������ ���׸���� ����
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}