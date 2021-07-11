using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The parent that contains the player bullet gameobjects")]
    private GameObject playerBulletsContainer;

    [SerializeField]
    [Tooltip("The parent that contains the enemy bullet gameobjects")]
    private GameObject enemyBulletsContainer;

    [SerializeField]
    private List<Bullet> playerBullets = new List<Bullet>();

    [SerializeField]
    private List<Bullet> enemyBullets = new List<Bullet>();

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Initialize player bullets
        Bullet[] playerBulletArray = playerBulletsContainer.GetComponentsInChildren<Bullet>(true);
        playerBullets = playerBulletArray.OfType<Bullet>().ToList();

        // Initialize enemy bullets
        Bullet[] enemyBulletArray = enemyBulletsContainer.GetComponentsInChildren<Bullet>(true);
        enemyBullets = enemyBulletArray.OfType<Bullet>().ToList();
    }
}
