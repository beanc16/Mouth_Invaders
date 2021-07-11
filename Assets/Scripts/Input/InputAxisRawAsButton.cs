using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxisRawAsButton
{
    private string axisName;
    private bool buttonWasClicked;

    public InputAxisRawAsButton(string axisName)
    {
        this.axisName = axisName;
        buttonWasClicked = false;
    }

    private bool isButtonBeingHeld
    {
        get
        {
            return Input.GetAxisRaw(this.axisName) > 0;
        }
    }



    public float GetAxisRawDown()
    {
        // Return output if button is being held, but hasn't been marked as clicked
        if (isButtonBeingHeld && !buttonWasClicked)
        {
            buttonWasClicked = true;
            return Input.GetAxisRaw(this.axisName);
        }

        // Reset button as not clicked when it is no longer being held
        else if (!isButtonBeingHeld && buttonWasClicked)
        {
            buttonWasClicked = false;
        }

        return 0;
    }
}
