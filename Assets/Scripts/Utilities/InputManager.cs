using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
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
}
