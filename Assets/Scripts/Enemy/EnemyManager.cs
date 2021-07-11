using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Range(0, 3)]
    private float minSecondsBetweenShots = 0.5f;
    [SerializeField, Range(0, 3)]
    private float maxSecondsBetweenShots = 1.5f;

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    private bool isFiring = false;

    public bool allEnemiesAreDead
    {
        get
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    return false;
                }
            }

            return true;
        }
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Initialize player bullets
        Enemy[] enemyArray = this.GetComponentsInChildren<Enemy>();
        enemies = enemyArray.OfType<Enemy>().ToList();
    }



    private void Update()
    {
        // Every min to max seconds, pick a random enemy, and fire a bullet
        if (!isFiring)
        {
            isFiring = true;
            StartCoroutine("FireBulletFromRandomEnemy");
        }
    }

    IEnumerator FireBulletFromRandomEnemy()
    {
        // Wait a random amount of seconds
        yield return WaitMinMaxSeconds();

        // Fire a bullet from a random enemy
        if (!allEnemiesAreDead)
        {
            Enemy enemy = GetRandomEnemy();
            enemy.FireBullet();
        }

        isFiring = false;
    }

    IEnumerator WaitMinMaxSeconds()
    {
        // Wait an amount of time between the min and max number of seconds
        float secsToWait = Random.Range(minSecondsBetweenShots, maxSecondsBetweenShots);
        yield return new WaitForSeconds(secsToWait);
    }

    private Enemy GetRandomEnemy()
    {
        float randomNum = Random.Range(0, enemies.Count);
        int randomIndex = (int)Mathf.Round(randomNum);
        Enemy enemy = enemies[randomIndex];

        if (!enemy.gameObject.activeSelf)
        {
            enemy = GetRandomEnemy();
        }

        return enemy;
    }
}
