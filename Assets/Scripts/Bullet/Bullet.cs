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

    private Rigidbody2D bulletRBody;
    private Renderer renderer;
    private HorizontalMover player;

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
        if (bulletRBody == null)
        {
            bulletRBody = GetComponent<Rigidbody2D>();
        }
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }

        // External components
        if (player == null)
        {
            player = FindObjectOfType<HorizontalMover>();
        }

        this.gameObject.SetActive(false);
    }



    public void Fire()
    {
        // Make the bullet visible
        this.gameObject.SetActive(true);

        // Move the bullet in front of player
        Vector3 newPosition = player.transform.position + player.transform.up;
        bulletRBody.MovePosition(newPosition);

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

        if (enemy != null)
        {
            enemy.Hide();
            this.StopMoving();
        }

        else if (player != null)
        {
            Debug.Log("Hit player!");
            this.StopMoving();
        }
    }
}
