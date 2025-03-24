using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_05_Movement : MonoBehaviour
{
    //Scripts Variables
    private Scr_Player_01_Control playerControl;
    private Scr_Player_02_State playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_08_Action playerAction;
    private Scr_Player_09_Animation playerAnimation;

    //Basic Variables
    public bool playerCanDoubleJump;

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Control>();
        playerState = GetComponent<Scr_Player_02_State>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
        playerAction = GetComponent<Scr_Player_08_Action>();
        playerAnimation = GetComponentInChildren<Scr_Player_09_Animation>();
    }

    //Handle Landing (Land/ Reset Jumps)
    public void HandleMovementLand()
    {
        //Player Land Code
        if (playerState.playerLand)
        {
            playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
            {
                Name = "Land",
                Animation = "Animation_Land",
                State1 = (action) => playerState.noCancelableAction = true
            });

            playerStatistics.playerActualJumpAmount = playerStatistics.playerJumpAmount;
            return;
        }
    }

    //Handle Grounded Movement (Idle /Walk /Run /Turn around)
    public void HandleMovementGrounded()
    {
        if (playerState.passiveAction && playerState.stateGrounded)
        {
            // Turn around
            transform.rotation = Quaternion.Euler(0, playerAction.rightSide ? 0 : 180, 0);

            // Horizontal Movement code
            if (playerControl.directionRight || playerControl.directionLeft)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = playerControl.leftTrigger ? "Run" : "Walk",
                    Animation = playerControl.leftTrigger ? "Animation_Run" : "Animation_Walk",
                    VelocityX = playerControl.leftTrigger ? playerStatistics.playerRunSpeed : playerStatistics.playerWalkSpeed,
                });
                return;
            }

            // Idle code
            if (playerControl.controlIdle || (!playerControl.directionRight && !playerControl.directionLeft))
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "Idle",
                    Animation = "Animation_Idle"
                });
            }
        }
    }

    //Handle Jump Movement (Fall /Jump /Double Jump)
    public void HandleMovementJump()
    {
        if (playerState.passiveAction)
        {
            // Jump code
            if (playerState.stateGrounded)
            {
                if (playerControl.button3 && playerStatistics.playerActualJumpAmount > 0)
                {
                    HandleJumpFunction("Jump", "Animation_Jump");
                    return;
                }
            }

            // Fall code
            if (playerState.stateAirborn)
            {
                //Fall
                if (playerAction.actualAction != "Jump" || playerAction.actualAction != "DoubleJump")
                {
                    playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                    {
                        Name = "Fall",
                        Animation = "Animation_Fall"
                    });
                }
            }
        }

        //Double Jump
        if (playerState.passiveAction || playerAnimation.AnimationEventFunction("Animation_Jump", 0.50f))
        {
            if (playerState.stateAirborn && playerControl.button3 && playerCanDoubleJump && playerStatistics.playerActualJumpAmount > 0)
            {
                HandleJumpFunction("DoubleJump", "Animation_DoubleJump");
                return;
            }
        }
    }

    //Jump code function
    private void HandleJumpFunction(string actionName, string animationName)
    {
        playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
        {
            Name = actionName,
            Animation = animationName,
            State1 = (action) => playerState.cancelableAction = true,
            VelocityY = playerStatistics.playerJumpForce
        });

        playerStatistics.playerActualJumpAmount--;
    }

}
