using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private bool startCollided = false;
    private bool exitCollided = false;

    void Update()
    {
        // space Ű�� ������ �� �� ��ȯ
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
        }
        else if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("����Ʈ �浹");
            exitCollided = true;
            startCollided = false;
        }
    }
}
