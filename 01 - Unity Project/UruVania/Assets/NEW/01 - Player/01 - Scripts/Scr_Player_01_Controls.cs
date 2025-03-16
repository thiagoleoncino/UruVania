using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Scr_Player_01_Controls : MonoBehaviour
{
    public enum controlTypes
    {
        Keyboard,
        Controller
    }

    public Player_Input_Manager playerActionControls;

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

    private void Awake()
    {
        playerActionControls = new Player_Input_Manager();
        playerActionControls.Enable();

        // Suscribirse al evento de la acción Input_Button_4
        NewInputs();
    }

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
        //NewInput();

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

    void NewInputs()
    {
        //Button 1 Detection (Poncho Attack)
        TapAndHoldButtonDetection(playerActionControls.Player_Action_Map.Input_Button_1, value => button1 = value, value => button1Tap = value, value => button1Hold = value);
        RealeseButtonDetection(playerActionControls.Player_Action_Map.Input_Button_1, value => button1Realase = value);

        //Button 3 Detection (Jump)
        PressButtonDetection(playerActionControls.Player_Action_Map.Input_Button_3, value => button3 = value);

        //Button 4 Detection (Normal Attack)
        TapAndHoldButtonDetection(playerActionControls.Player_Action_Map.Input_Button_4, value => button4 = value, value => button4Tap = value, value => button4Hold = value);
        RealeseButtonDetection(playerActionControls.Player_Action_Map.Input_Button_4, value => button4Realase = value);

        //Trigger 1
        AllButtonDetection(playerActionControls.Player_Action_Map.Input_Trigger_1, value => leftTrigger = value);
    }

    void AllButtonDetection(InputAction inputAction, Action<bool> setButtonState)
    {
        inputAction.performed += ctx => setButtonState(true);
        inputAction.canceled += ctx => setButtonState(false);
    }

    void PressButtonDetection(InputAction inputAction, Action<bool> setButtonState)
    {
        inputAction.performed += ctx =>
        {
            setButtonState(true); // Activa el botón cuando la acción es ejecutada
            StartCoroutine(ButtonTimeout(setButtonState)); // Inicia la corutina para apagar la bool después de un segundo
        };
    }

    void TapAndHoldButtonDetection(InputAction inputAction, Action<bool> setButtonState, Action<bool> setTapButton, Action<bool> setHoldButton)
    {
        inputAction.started += ctx => setButtonState(true);

        inputAction.performed += ctx =>
        {
            if (ctx.interaction is TapInteraction)
            {
                setTapButton(true);
                StartCoroutine(ButtonTimeout(setTapButton));
                StartCoroutine(ButtonTimeout(setButtonState));
            }
            else if (ctx.interaction is HoldInteraction)
            {
                setHoldButton(true);
                StartCoroutine(ButtonTimeout(setButtonState));
            }
        };

        inputAction.canceled += ctx =>
        {
            setButtonState(false);
            setTapButton(false);
            setHoldButton(false);
        };
  
    }

    void RealeseButtonDetection(InputAction inputAction, Action<bool> setRealaseButton)
    {
        inputAction.canceled += ctx =>
        {
            if (ctx.interaction is HoldInteraction)
            {
                setRealaseButton(true);
                StartCoroutine(ButtonTimeout(setRealaseButton)); // Después de un tiempo, la variable se desactiva
            }
        };
    }

    IEnumerator ButtonTimeout(Action<bool> setButtonState)
    {
        yield return new WaitForSeconds(0.2f); // Espera 1 segundo
        setButtonState(false); // Apaga la bool después del tiempo
    }
}