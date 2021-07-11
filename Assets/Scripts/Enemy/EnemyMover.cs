using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    private float movementSpeed = 1;
    [SerializeField, Range(0, 1)]
    private float downwardStep = 0.25f;

    private MovementDirection curDirection = MovementDirection.Left;
    private bool hasSwappedDirection = false;



    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        Vector3 moveDirection = this.transform.right * movementSpeed * Time.deltaTime;

        // Move left
        if (curDirection == MovementDirection.Left)
        {
            moveDirection = moveDirection * -1;
        }

        this.transform.Translate(moveDirection);
    }

    public void SwapDirections()
    {
        if (!hasSwappedDirection)
        {
            if (curDirection == MovementDirection.Left)
            {
                curDirection = MovementDirection.Right;
                hasSwappedDirection = true;
            }

            else if (curDirection == MovementDirection.Right)
            {
                curDirection = MovementDirection.Left;
                hasSwappedDirection = true;
            }

            MoveDown();
        }
    }

    public void StopSwappingDirections()
    {
        hasSwappedDirection = false;
    }

    private void MoveDown()
    {
        Vector3 movementStep = new Vector3(0, downwardStep * 1);
        this.transform.position -= movementStep;
    }
}



public enum MovementDirection
{
    Left,
    Right
}
