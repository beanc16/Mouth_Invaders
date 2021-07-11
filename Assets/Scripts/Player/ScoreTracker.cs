using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField, Tooltip("How much to increase score by for each enemy killed")]
    private int scoreStep = 100;
    [SerializeField]
    private TMP_Text scoreText;
    private string baseStr = "Score: ";

    public static int gameOverScore = 0;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        if (scoreText == null)
        {
            Debug.LogWarning("Score text not set");
        }
    }



    public void IncreaseScore()
    {
        // Increase score and update display text
        score += scoreStep;
        scoreText.SetText(baseStr + score);

        // Update gameOverScore
        ScoreTracker.gameOverScore = this.score;
    }
}
