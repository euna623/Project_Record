using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public Material collidedMaterial; // 충돌 시 적용할 메테리얼

    private bool startCollided = false;
    private bool exitCollided = false;

    private Material originalMaterial; // 원래의 메테리얼

    void Start()
    {
        // 오브젝트의 원래 메테리얼 저장
        originalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Space 키를 눌렀을 때 씬 전환
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

            // 충돌 시 메테리얼 변경
            GetComponent<Renderer>().material = collidedMaterial;
        }
        else if (collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("엑시트 충돌");
            exitCollided = true;
            startCollided = false;

            // 충돌 시 메테리얼 변경
            GetComponent<Renderer>().material = collidedMaterial;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Start") || collider.gameObject.CompareTag("Exit"))
        {
            // 충돌 해제 시 원래의 메테리얼로 복구
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
