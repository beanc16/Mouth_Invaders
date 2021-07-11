using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class HorizontalMover : MonoBehaviour
{
    [SerializeField, Range(0, 15)]
    private float movementSpeed = 1f;

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
        if (InputManager.isMovingLeft)
        {
            Vector3 moveDistance = (this.transform.right * -1) * 
                                    movementSpeed * Time.deltaTime;
            this.transform.Translate(moveDistance);
        }

        // Move right
        else if (InputManager.isMovingRight)
        {
            Vector3 moveDistance = this.transform.right * 
                                    movementSpeed * Time.deltaTime;
            this.transform.Translate(moveDistance);
        }
    }
}
