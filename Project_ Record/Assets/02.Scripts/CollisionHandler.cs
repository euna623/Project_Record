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
        // space 키를 눌렀을 때 씬 전환
        if (startCollided && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        else if (exitCollided && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("나가기");
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Start"))
        {
            Debug.Log("스타트 충돌");
            startCollided = true;
            exitCollided = false;
        }
        else if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("엑시트 충돌");
            exitCollided = true;
            startCollided = false;
        }
    }
}
