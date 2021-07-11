using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private EnemyManager enemyManager;
    private BulletManager bulletManager;
    private LivesTracker livesTracker;
    [SerializeField]
    private GameObject victoryUiPanel;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        bulletManager = FindObjectOfType<BulletManager>();
        livesTracker = FindObjectOfType<LivesTracker>();

        if (victoryUiPanel == null)
        {
            Debug.LogWarning("Must set victoryUiPanel for StateManager");
        }
    }



    public bool playerHasWon
    {
        get
        {
            return enemyManager.allEnemiesAreDead;
        }
    }

    public bool playerHasLost
    {
        get
        {
            return livesTracker.isDead;
        }
    }



    public void TryToWin()
    {
        if (playerHasWon)
        {
            victoryUiPanel.SetActive(true);
            bulletManager.DisableAllBullets();
        }
    }

    public void TryToLose()
    {
        if (playerHasLost)
        {
            SceneHandler.LoadScene("GameOver");
        }
    }
}
