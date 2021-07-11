using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesTracker : MonoBehaviour
{
    private StateManager stateManager;

    [SerializeField, Range(0, 3)]
    private int lives = 3;
    [SerializeField]
    private TMP_Text livesText;
    private string baseStr = "Lives: ";

    public bool isDead
    {
        get
        {
            return (lives <= 0);
        }
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        if (livesText == null)
        {
            Debug.LogWarning("Lives text not set");
        }

        stateManager = FindObjectOfType<StateManager>();
    }



    public void LoseLife()
    {
        // Lose a life and update display text
        lives--;
        livesText.SetText(baseStr + lives);
        
        // Try to activate the game over state
        stateManager.TryToLose();
    }

    public void Kill()
    {
        // Lose all lives and update display text
        lives = 0;
        livesText.SetText(baseStr + lives);
        
        // Activate the game over state
        stateManager.TryToLose();
    }
}
