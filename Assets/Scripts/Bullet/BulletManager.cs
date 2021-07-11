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

    private HorizontalMover player;



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

        // Initialize player
        player = FindObjectOfType<HorizontalMover>();
    }



    public void FireBullet(bool isPlayerBullet)
    {
        Bullet bullet;

        // Get inactive player bullet
        if (isPlayerBullet)
        {
            bullet = GetInactiveBullet(playerBullets);
        }
        // Get inactive enemy bullet
        else
        {
            bullet = GetInactiveBullet(enemyBullets);
        }

        bullet.gameObject.SetActive(true);

        // Move the bullet in front of player
        Vector3 newPosition = player.transform.position + player.transform.up;
        Rigidbody2D bulletRBody = bullet.GetComponent<Rigidbody2D>();
        bulletRBody.MovePosition(newPosition);

        // Fire bullet
    }

    private Bullet GetInactiveBullet(List<Bullet> bulletList)
    {
        foreach (Bullet bullet in bulletList)
        {
            if (!bullet.gameObject.activeSelf)
            {
                return bullet;
            }
        }

        // Create bullet if there aren't any inactive bullets

        return null;
    }
}
