using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private BulletManager bulletManager;
    private EnemyMover enemyMover;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        enemyMover = FindObjectOfType<EnemyMover>();
    }



    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void FireBullet()
    {
        bulletManager.FireBullet(false, this);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Move in opposite direction when hitting one side of the screen
        if (other.gameObject.CompareTag("Enemy Wall"))
        {
            enemyMover.SwapDirections();
        }

        else
        {
            LivesTracker player = other.gameObject.GetComponent<LivesTracker>();
            
            if (player != null)
            {
                player.Kill();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy Wall"))
        {
            enemyMover.StopSwappingDirections();
        }
    }
}
