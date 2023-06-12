using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Score를 표시할 텍스트 UI
    private int score = 0; // 현재 Score 값

    public GameObject menuSet;

    public AudioSource musicSource; // AudioSource 컴포넌트

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

        // AudioSource의 재생이 끝났을 때 GameSet 씬으로 전환
        if (!musicSource.isPlaying)
        {
            LoadGameSetScene();
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

    private void LoadGameSetScene()
    {
        SceneManager.LoadScene("GameSet"); // GameSet 씬으로 전환
    }
}
