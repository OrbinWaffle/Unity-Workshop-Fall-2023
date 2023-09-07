using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;
    public static ScoreManager main;
    void Awake()
    {
        main = this;
    }
    public void ChangeScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
