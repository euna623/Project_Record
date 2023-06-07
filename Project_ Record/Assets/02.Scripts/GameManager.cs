using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score�� ǥ���� �ؽ�Ʈ UI
    private int score = 0; // ���� Score ��

    private void Start()
    {
        UpdateScoreText();
    }

    // Score ���� ������Ű�� �ؽ�Ʈ ������Ʈ
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // �ؽ�Ʈ UI�� Score ���� ������Ʈ
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
