using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (Collider2D))]
public class HorizontalMover : MonoBehaviour
{
    [SerializeField, Range(0, 15)]
    private float movementSpeed = 1f;
    private bool isCollidingWithLeftWall = false;
    private bool isCollidingWithRightWall = false;

    private Rigidbody2D rBody;

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        rBody = this.GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        // Move left
        if (InputManager.isMovingLeft && !isCollidingWithLeftWall)
        {
            Vector3 moveDistance = (this.transform.right * -1) * 
                                    movementSpeed * Time.deltaTime;
            this.transform.Translate(moveDistance);
        }

        // Move right
        else if (InputManager.isMovingRight && !isCollidingWithRightWall)
        {
            Vector3 moveDistance = this.transform.right * 
                                    movementSpeed * Time.deltaTime;
            this.transform.Translate(moveDistance);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerWall wall = other.gameObject.GetComponent<PlayerWall>();

        if (wall != null)
        {
            if (wall.wallSide == WallSide.Left)
            {
                isCollidingWithLeftWall = true;
            }

            else if (wall.wallSide == WallSide.Right)
            {
                isCollidingWithRightWall = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerWall wall = other.gameObject.GetComponent<PlayerWall>();

        if (wall != null)
        {
            if (wall.wallSide == WallSide.Left)
            {
                isCollidingWithLeftWall = false;
            }

            else if (wall.wallSide == WallSide.Right)
            {
                isCollidingWithRightWall = false;
            }
        }
    }
}
