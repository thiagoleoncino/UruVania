using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Scr_Player_01_Controls : MonoBehaviour
{
    //Reference to the Input Asset
    public Player_Input_Manager playerActionControls;
    
    //Bools for buttons inputs and buttons functions
    #region 
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
    public bool button1Tap;
    public bool button1Hold;
    public bool button1Realase;

    [Space]
    public bool button2;
    public bool button2Tap;
    public bool button2Hold;
    public bool button2Realase;

    [Space]
    public bool button3;

    [Space]
    public bool button4;
    public bool button4Tap;
    public bool button4Hold;
    public bool button4Realase;

    [Space]
    public bool leftTrigger;
    public bool rightTrigger;

    [Space]
    public bool buttonStart;
    public bool buttonSelect;

    #endregion

    //Awake is the first thing to update
    private void Awake()
    {
        playerActionControls = new Player_Input_Manager();
        playerActionControls.Enable();

        ButtonInputsFunction();
    }

    //Update is called once per frame
    void Update()
    {
        //If no input is active
        controlIdle = !(directionUp || directionRight || directionDown || directionLeft || directionDiagonalUpRight || directionDiagonalDownRight ||
        directionDiagonalDownLeft || directionDiagonalUpLeft || button1 || button2 || button3 || button4 || leftTrigger || rightTrigger || buttonStart || buttonSelect);

        MoveInputsFunction();
    }

    //Move inputs function
    void MoveInputsFunction()
    {
        //Gets the Movment Inputs
        Vector2 moveInput = playerActionControls.Player_Action_Map.Input_Normal_Movement.ReadValue<Vector2>();
        float horizontal = moveInput.x;
        float vertical = moveInput.y;

        //Resets the direction
        directionRight = false;
        directionLeft = false;
        directionUp = false;
        directionDown = false;
        directionDiagonalUpRight = false;
        directionDiagonalDownRight = false;
        directionDiagonalDownLeft = false;
        directionDiagonalUpLeft = false;

        //Direction Bools
        if (vertical > 0 && horizontal > 0) //Diagonal Up Right
        {
            directionDiagonalUpRight = true;
        }
        else if (vertical < 0 && horizontal > 0) //Diagonal Down Right
        {
            directionDiagonalDownRight = true;
        }
        else if (vertical < 0 && horizontal < 0) //Diagonal Down Left
        {
            directionDiagonalDownLeft = true;
        }
        else if (vertical > 0 && horizontal < 0) //Diagonal Up Left
        {
            directionDiagonalUpLeft = true;
        }
        else //If not diagonal
        {
            if (horizontal > 0) directionRight = true; //Button Right
            if (horizontal < 0) directionLeft = true; //Button Left
            if (vertical > 0) directionUp = true; //Button Up
            if (vertical < 0) directionDown = true; //Button Down
        }
    }

    //Buttons inputs function
    void ButtonInputsFunction()
    {
        //Button 1 Detection (Poncho Attack)
        ButtonActionsDetectionFunction(playerActionControls.Player_Action_Map.Input_Button_1,
        value => button1 = value,
        value => button1Tap = value,
        value => button1Hold = value,
        value => button1Realase = value);

        //Button 2 Detection (Object)
        ButtonActionsDetectionFunction(playerActionControls.Player_Action_Map.Input_Button_2,
        value => button2 = value,
        value => button2Tap = value,
        value => button2Hold = value,
        value => button2Realase = value);

        //Button 3 Detection (Jump)
        PressButtonDetectionFunction(playerActionControls.Player_Action_Map.Input_Button_3, value => button3 = value);

        //Button 4 Detection (Normal Attack)
        ButtonActionsDetectionFunction(playerActionControls.Player_Action_Map.Input_Button_4,
        value => button4 = value,
        value => button4Tap = value,
        value => button4Hold = value,
        value => button4Realase = value);

        //Trigger 1
        AllButtonDetectionFunction(playerActionControls.Player_Action_Map.Input_Trigger_1, value => leftTrigger = value);

        //Trigger 2
        AllButtonDetectionFunction(playerActionControls.Player_Action_Map.Input_Trigger_2, value => rightTrigger = value);
    }

    //Detects the button completely
    void AllButtonDetectionFunction(InputAction inputAction, Action<bool> setButtonState)
    {
        inputAction.performed += ctx => setButtonState(true);
        inputAction.canceled += ctx => setButtonState(false);
    }

    //Detects the button and turns it off after a few moments
    void PressButtonDetectionFunction(InputAction inputAction, Action<bool> setButtonState)
    {
        inputAction.performed += ctx =>
        {
            setButtonState(true); 
            StartCoroutine(ButtonTimeoutCoroutine(setButtonState));
        };
    }

    //Detects the button functions, Tap, Hold and Release
    void ButtonActionsDetectionFunction(InputAction inputAction, Action<bool> onPressed, Action<bool> onTap, Action<bool> onHold, Action<bool> onRelease)
    {
        inputAction.started += ctx => onPressed(true);

        inputAction.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                onTap(true);
                StartCoroutine(ButtonTimeoutCoroutine(onPressed));
                StartCoroutine(ButtonTimeoutCoroutine(onTap));
            }
            else if (ctx.interaction is HoldInteraction)
            {
                onHold(true);
            }
        };

        inputAction.canceled += ctx =>
        {
            onPressed(false);
            onTap(false);
            onHold(false);

            if (ctx.interaction is HoldInteraction)
            {
                onRelease(true);
                StartCoroutine(ButtonTimeoutCoroutine(onRelease));
            }
        };
    }

    //Timer to turn off buttons
    IEnumerator ButtonTimeoutCoroutine(Action<bool> setButtonState)
    {
        yield return new WaitForSeconds(0.2f);
        setButtonState(false);
    }
}