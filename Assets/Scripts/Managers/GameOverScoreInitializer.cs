using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreInitializer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    private string baseStr = "Score: ";

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



    private void Start()
    {
        scoreText.SetText(baseStr + ScoreTracker.gameOverScore);
    }
}
