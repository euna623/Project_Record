using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score를 표시할 텍스트 UI
    private int score = 0; // 현재 Score 값

    public GameObject menuSet;
    public AudioSource musicSource;

    private void Start()
    {
        // 이전 씬에서 저장된 Score 값을 불러옴
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

        // AudioSource의 재생이 끝나면 GameSet 씬으로 이동
        if (musicSource != null && !musicSource.isPlaying)
        {
            // Score 값을 PlayerPrefs에 저장
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameSet");
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
