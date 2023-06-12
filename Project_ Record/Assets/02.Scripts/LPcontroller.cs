using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPcontroller : MonoBehaviour
{
    public Material targetMaterial; // 충돌 대상 메테리얼
    private GameManager gameManager; // GameManager 오브젝트에 연결된 GameManager 스크립트 참조

    private void Start()
    {
        // GameManager 오브젝트의 GameManager 스크립트 참조
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Renderer renderer = collider.gameObject.GetComponent<Renderer>();
        if (renderer != null && renderer.sharedMaterial != targetMaterial)
        {
            if (gameManager.GetScore() > 0) // Score가 0보다 큰 경우에만 실행
            {
                gameManager.IncreaseScore(-10);
            }
            Destroy(collider.gameObject);
        }
        else if (renderer != null && renderer.sharedMaterial == targetMaterial)
        {
            Destroy(collider.gameObject);
            if (gameManager != null)
            {
                // Score를 10 증가시킴
                gameManager.IncreaseScore(10);
            }
        }
    }
}
