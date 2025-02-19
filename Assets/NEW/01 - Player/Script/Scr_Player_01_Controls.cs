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

    // Update is called once per frame
    private void FixedUpdate()
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

        button3 = Input.GetButton("Jump");

        leftTrigger = Input.GetKey(KeyCode.LeftShift);
    }
}
