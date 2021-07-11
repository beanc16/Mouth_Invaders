using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputAxisRawAsButton fireInputAsButton = new InputAxisRawAsButton("Fire1");



    /*
     * Inputs
     */
    
    public static float horizontalInput
    {
        get
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }

    public static float fireInput
    {
        get
        {
            return fireInputAsButton.GetAxisRawDown();
        }
    }



    /*
     * Booleans
     */
    
    public static bool isMovingLeft
    {
        get
        {
            return horizontalInput < 0;
        }
    }

    public static bool isMovingRight
    {
        get
        {
            return horizontalInput > 0;
        }
    }

    public static bool isStationary
    {
        get
        {
            return horizontalInput == 0;
        }
    }

    public static bool shouldFire
    {
        get
        {
            return fireInput != 0;
        }
    }
}
