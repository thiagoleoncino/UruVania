using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_05_Actions : MonoBehaviour
{
    //Scripts Variables
    private Scr_Player_01_Controls playerControl;
    private Scr_Player_02_States playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_04_Physics playerPhisic;
    private Scr_Player_06_Animations playerAnimation;

    //Basic Variables
    public string actualAction;
    [Space]
    public bool rightSide;
    public bool playerCanDoubleJump;

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Controls>();
        playerState = GetComponent<Scr_Player_02_States>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
        playerPhisic = GetComponent<Scr_Player_04_Physics>();
        playerAnimation = GetComponentInChildren<Scr_Player_06_Animations>();
    }

    //Update is called once per frame
    void Update()
    {
        //Player Land Code
        if (playerState.playerLand)
        {
            HandleActionsFunction("Land", "Animation_Land");
            playerState.noCancelableAction = true;
            return;
        }

        //Reset State to Passive Action
        HandleStateFunction();

        // Passive Actions
        if (playerState.passiveAction)
        {
            // Actions in the Ground
            if (playerState.stateGrounded)
            {
                //Reset Jump
                playerStatistics.playerActualJumpAmount = playerStatistics.playerJumpAmount;

                // Turn around
                transform.rotation = Quaternion.Euler(0, rightSide ? 0 : 180, 0);

                // Jump code
                if (playerControl.button3 && playerStatistics.playerActualJumpAmount > 0)
                {
                    HandleJumpFunction("Jump", "Animation_Jump");
                    return; 
                }

                // Horizontal Movement code
                if (playerControl.directionRight || playerControl.directionLeft)
                {
                    HandleActionsFunction(playerControl.leftTrigger ? "Run" : "Walk", playerControl.leftTrigger ? "Animation_Run" : "Animation_Walk");

                    rightSide = playerControl.directionRight;
                    float speed = playerControl.leftTrigger ? playerStatistics.playerRunSpeed : playerStatistics.playerWalkSpeed;
                    playerPhisic.PlayerHorizontalMoveFunction(rightSide ? speed : -speed);

                    return; 
                }

                // Idle code
                if (playerControl.controlIdle || (!playerControl.directionRight && !playerControl.directionLeft))
                {
                    HandleActionsFunction("Idle", "Animation_Idle");

                    playerPhisic.PlayerHorizontalMoveFunction(0);
                }

            }

            //Actions in the Air
            if (playerState.stateAirborn)
            {
                // Fall code
                if (actualAction != "Jump" || actualAction != "DoubleJump" )
                {
                    HandleActionsFunction("Fall", "Animation_Fall");
                }
            }

        }

        //Double Jump Code
        HandleExtraJumpsFunction();

    }

    //General action function
    private void HandleActionsFunction(string actionName, string animationName)
    {
        actualAction = actionName;
        playerAnimation.ChangeAnimationFunction(animationName);
    }

    //Jump code function
    private void HandleJumpFunction(string actionName, string animationName)
    {
        HandleActionsFunction(actionName, animationName);

        playerPhisic.PlayerVerticalMoveFunction(playerStatistics.playerJumpForce);
        playerState.cancelableAction = true;
        playerStatistics.playerActualJumpAmount--;
    }

    private void HandleExtraJumpsFunction()
    {
        if (playerState.passiveAction || playerAnimation.AnimationEventFunction("Animation_Jump", 0.50f))
        {
            if (playerState.stateAirborn && playerCanDoubleJump && playerControl.button3 && playerStatistics.playerActualJumpAmount > 0)
            {
                HandleJumpFunction("DoubleJump", "Animation_DoubleJump");
                return;
            }
        }
    }

    //Change of state function
    private void ResetStateFunction(string animationName)
    {
        if (playerAnimation.AnimationEventFunction(animationName, 0.95f))
        {
            playerState.passiveAction = true;
        }
    }

    //All actions that need a change of state at the end
    private void HandleStateFunction()
    {
        ResetStateFunction("Animation_Jump");
        ResetStateFunction("Animation_DoubleJump");
        ResetStateFunction("Animation_Land");
    }

}
