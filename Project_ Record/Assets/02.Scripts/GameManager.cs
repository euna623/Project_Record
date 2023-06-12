using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score�� ǥ���� �ؽ�Ʈ UI
    private int score = 0; // ���� Score ��

    public GameObject menuSet;

    public AudioSource musicSource; // AudioSource ������Ʈ

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

        // AudioSource�� ����� ������ �� GameSet ������ ��ȯ
        if (!musicSource.isPlaying)
        {
            LoadGameSetScene();
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

    private void LoadGameSetScene()
    {
        SceneManager.LoadScene("GameSet"); // GameSet ������ ��ȯ
    }
}
