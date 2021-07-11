using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesTracker : MonoBehaviour
{
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
    }



    public void LoseLife()
    {
        lives--;
        livesText.SetText(baseStr + lives);
    }
}
