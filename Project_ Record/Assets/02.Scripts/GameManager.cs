using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score�� ǥ���� �ؽ�Ʈ UI
    private int score = 0; // ���� Score ��

    public GameObject menuSet;
    public AudioSource musicSource;

    private void Start()
    {
        // ���� ������ ����� Score ���� �ҷ���
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreText();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Debug.Log(false);
            }
            else
            {
                menuSet.SetActive(true);
                Debug.Log(true);
            }
        }

        // AudioSource�� ����� ������ GameSet ������ �̵�
        if (musicSource != null && !musicSource.isPlaying)
        {
            // Score ���� PlayerPrefs�� ����
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameSet");
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

    public void ReStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void Active()
    {
        menuSet.SetActive(false);
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
}
