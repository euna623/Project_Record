using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreViewer : MonoBehaviour
{
    private Text textResultScore;

    private void Awake()
    {
        textResultScore = GetComponent<Text>();
        int score = PlayerPrefs.GetInt("Score");
        textResultScore.text = "Score : " + score;
    }
}
