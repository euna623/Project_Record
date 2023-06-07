using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score를 표시할 텍스트 UI
    private int score = 0; // 현재 Score 값

    private void Start()
    {
        UpdateScoreText();
    }

    // Score 값을 증가시키고 텍스트 업데이트
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // 텍스트 UI에 Score 값을 업데이트
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
