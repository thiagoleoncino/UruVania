using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_05_Actions : MonoBehaviour
{
    private Scr_Player_01_Controls playerControl;
    private Scr_Player_02_States playerState;
    private Scr_Player_03_Statistics playerStat;
    private Scr_Player_04_Physics playerPhisic;
    private Scr_Player_06_Animations playerAnimation;
    private Scr_Player_07_Combat playerCombat;

    // Basic Variables
    public int totalJumps;
    public string actualAction;
    public bool rightSide;

    [Space] //Extra skills bools 
    public bool playerCanDoubleJump;

    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Controls>();
        playerState = GetComponent<Scr_Player_02_States>();
        playerStat = GetComponent<Scr_Player_03_Statistics>();
        playerPhisic = GetComponent<Scr_Player_04_Physics>();
        playerAnimation = GetComponentInChildren<Scr_Player_06_Animations>();
        playerCombat = GetComponentInChildren<Scr_Player_07_Combat>();
    }

    void Start()
    {
        totalJumps = playerStat.playerJumpAmount;
    }

    void Update()
    {
        // Passive Actions
        if (playerState.passiveAction)
        {
            // Actions in the Ground
            if (playerState.stateGrounded)
            {
                //Reset Jump
                totalJumps = playerStat.playerJumpAmount;

                // Turn around
                transform.rotation = Quaternion.Euler(0, rightSide ? 0 : 180, 0);

                // Jump
                if (playerControl.button3 && totalJumps > 0)
                {
                    actualAction = "Jump";
                    playerPhisic.PlayerVerticalMoveFunction(playerStat.playerJumpForce);
                    playerAnimation.ChangeAnimation("Anim_Player_04_Jump");
                    playerState.cancelableAction = true;
                    totalJumps--;
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                // Horizontal Movement
                if (playerControl.directionRight || playerControl.directionLeft)
                {
                    rightSide = playerControl.directionRight;
                    actualAction = playerControl.leftTrigger ? "Run" : "Walk";
                    float speed = playerControl.leftTrigger ? playerStat.playerRunSpeed : playerStat.playerWalkSpeed;

                    playerPhisic.PlayerHorizontalMoveFunction(rightSide ? speed : -speed);
                    playerAnimation.ChangeAnimation(playerControl.leftTrigger ? "Anim_Player_03_Run" : "Anim_Player_02_Walk");
                }

                // Idle
                if (playerControl.controlIdle || (!playerControl.directionRight && !playerControl.directionLeft))
                {
                    actualAction = "Idle";
                    playerPhisic.PlayerHorizontalMoveFunction(0);
                    playerAnimation.ChangeAnimation("Anim_Player_01_Idle");
                    playerState.passiveAction = true;
                    return; // Evita que continúe evaluando otras acciones
                }

            }

            //Actions in the Air
            if (playerState.stateAirborn)
            {
                // Fall
                if (actualAction != "Jump" || actualAction != "DoubleJump" || playerAnimation.AnimationFinished("Anim_Player_04_Jump") || playerAnimation.AnimationFinished("Anim_Player_05_DoubleJump"))
                {
                    actualAction = "Fall";
                    playerAnimation.ChangeAnimation("Anim_Player_07_Fall");
                    playerState.passiveAction = true;
                }


                if(playerCanDoubleJump)
                {
                    // Jump (solo se ejecuta si no estamos ya en el aire haciendo un salto)
                    if (playerControl.button3 && totalJumps > 0)
                    {
                        actualAction = "DoubleJump";
                        playerPhisic.PlayerVerticalMoveFunction(playerStat.playerJumpForce);
                        playerAnimation.ChangeAnimation("Anim_Player_05_DoubleJump");
                        playerState.cancelableAction = true;
                        totalJumps--;
                        return; // Evita que se ejecuten otras acciones en el mismo frame
                    }
                }
            }

        }
    }

    public void Amen()
    {
        // XXXXXXXXXXXXXXXX
        if (playerControl.button4)
        {
            actualAction = "NormalAttack1";
            playerAnimation.ChangeAnimation("Anim_Player_09_NormalAttack2");
            playerState.semiCancelableAction = true;
            //return; // Evita que se ejecuten otras acciones en el mismo frame
        }
    }
}