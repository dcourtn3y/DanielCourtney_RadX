using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;
    public int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void updateScore()
    {
        ScoreText.text = "Score 0" + score;
    }
    // Update is called once per frame
    void Update()
    {
        updateScore();
    }
}
