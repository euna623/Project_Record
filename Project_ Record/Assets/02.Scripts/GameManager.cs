using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score�� ǥ���� �ؽ�Ʈ UI
    private int score = 0; // ���� Score ��

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

    // Score ���� ������Ű�� �ؽ�Ʈ ������Ʈ
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    // �ؽ�Ʈ UI�� Score ���� ������Ʈ
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
        Debug.Log("���� ����");
    }
}
