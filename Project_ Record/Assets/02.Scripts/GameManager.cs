using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score를 표시할 텍스트 UI
    private int score = 0; // 현재 Score 값

    public GameObject menuSet;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
            }
            else
            {
                menuSet.SetActive(true);
            }
        }
    }

    // Score 값을 증가시키고 텍스트 업데이트
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    // 텍스트 UI에 Score 값을 업데이트
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void GameExit()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
}
