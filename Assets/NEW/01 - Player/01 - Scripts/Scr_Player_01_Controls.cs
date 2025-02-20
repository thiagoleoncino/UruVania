using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ScrollRect;

public class Scr_Player_01_Controls : MonoBehaviour
{
    public enum controlTypes
    {
        Keyboard,
        Controller
    }

    [SerializeField] private controlTypes selectedController;

    [Space]
    public bool controlIdle;

    [Space]
    public bool directionUp;
    public bool directionRight;
    public bool directionDown;
    public bool directionLeft;

    [Space]
    public bool directionDiagonalUpRight;
    public bool directionDiagonalDownRight;
    public bool directionDiagonalDownLeft;
    public bool directionDiagonalUpLeft;

    [Space]
    public bool button1;
    public bool button2;
    public bool button3;
    public bool button4;

    [Space]
    public bool leftTrigger;
    public bool rightTrigger;
    
    [Space]
    public bool buttonStart;
    public bool buttonSelect;

    void Update()
    {
        //No input
        controlIdle = !(directionUp || directionRight || directionDown || directionLeft ||directionDiagonalUpRight || directionDiagonalDownRight || 
        directionDiagonalDownLeft || directionDiagonalUpLeft || button1 || button2 || button3 || button4 || leftTrigger || rightTrigger || buttonStart || buttonSelect);

        if (selectedController == controlTypes.Keyboard)
        {
            KeyboardInputs();
        }

    }

    void KeyboardInputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        directionRight = horizontal > 0;
        directionLeft = horizontal < 0;
        directionUp = vertical > 0;
        directionDown = vertical < 0;

        directionDiagonalUpRight = vertical > 0 && horizontal > 0;
        directionDiagonalDownRight = vertical < 0 && horizontal > 0;
        directionDiagonalDownLeft = vertical < 0 && horizontal < 0;
        directionDiagonalUpLeft = vertical > 0 && horizontal < 0;

        UpdateButtonState(KeyCode.Space, ref button3);
        UpdateButtonState(KeyCode.LeftShift, ref leftTrigger);
    }    

    void UpdateButtonState(KeyCode key, ref bool buttonState)
    {
        if (Input.GetKeyDown(key))
        {
            buttonState = true;
        }
        if (Input.GetKeyUp(key))
        {
            buttonState = false;
        }
    }
}