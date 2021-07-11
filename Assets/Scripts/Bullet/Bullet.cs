using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0, 15)]
    private float movementSpeed = 5;
    [SerializeField]
    private bool isPlayerBullet = false;
    private bool shouldMove = false;

    private Renderer renderer;
    private HorizontalMover player;
    private StateManager stateManager;

    private bool isOffScreen
    {
        get
        {
            return !renderer.isVisible;
        }
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Internal components
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }

        // External components
        if (player == null)
        {
            player = FindObjectOfType<HorizontalMover>();
        }
        if (stateManager == null)
        {
            stateManager = FindObjectOfType<StateManager>();
        }

        this.gameObject.SetActive(false);
    }



    public void Fire(Enemy enemy)
    {
        // Make the bullet visible
        this.gameObject.SetActive(true);

        // Move the bullet in front of player
        Vector3 newPosition = Vector3.zero;
        if (isPlayerBullet)
        {
            newPosition = player.transform.position + (player.transform.up / 1.5f);
        }
        else
        {
            if (enemy != null)
            {
                newPosition = enemy.transform.position + (enemy.transform.up * -1);
            }
            else
            {
                Debug.LogWarning("Tried to fire enemy bullet " + 
                                 "without saying which enemy fired it");
            }
        }

        if (!newPosition.Equals(Vector3.zero))
        {
            this.transform.position = newPosition;
        }

        // Mark the bullet as moving for FixedUpdate
        shouldMove = true;
    }



    private void FixedUpdate()
    {
        TryMove();
        TryHide();
    }

    private void TryMove()
    {
        if (shouldMove)
        {
            Vector3 moveDirection;

            // Player bullet
            if (isPlayerBullet)
            {
                moveDirection = this.transform.up;
            }
            // Enemy bullet
            else
            {
                moveDirection = this.transform.up * -1;
            }

            Vector3 moveDistance = moveDirection * 
                                    movementSpeed * Time.deltaTime;
            this.transform.Translate(moveDistance);
        }
    }

    private void TryHide()
    {
        if (shouldMove && isOffScreen)
        {
            StopMoving();
        }
    }

    public void StopMoving()
    {
        shouldMove = false;
        this.gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        HorizontalMover player = other.GetComponent<HorizontalMover>();

        // Hit an enemy with a player bullet
        if (enemy != null && isPlayerBullet)
        {
            // Hide the enemy and this bullet
            enemy.Hide();
            this.StopMoving();

            // Try to activate the win state
            stateManager.TryToWin();
        }

        // Hit a player with an enemy bullet
        else if (player != null && !isPlayerBullet)
        {
            // Lose a life
            LivesTracker livesTracker = player.GetComponent<LivesTracker>();
            livesTracker.LoseLife();

            // Hide this bullet
            this.StopMoving();
        }
    }
}
