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

    //Basic Variables
    public int totalJumps;
    public string actualAction;
    public bool rightSide;

    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Controls>();
        playerState = GetComponent<Scr_Player_02_States>();
        playerStat = GetComponent<Scr_Player_03_Statistics>();
        playerPhisic = GetComponent<Scr_Player_04_Physics>();
        playerAnimation = GetComponentInChildren<Scr_Player_06_Animations>();
    }
    void Start()
    {
        totalJumps = playerStat.playerJumpAmount;
    }

    // Update is called once per frame
    void Update()
    {
        //Actions in the Ground
        if (playerState.stateGrounded)
        {
            totalJumps = playerStat.playerJumpAmount;
            if(rightSide)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else { transform.eulerAngles = new Vector3(0, 180, 0); }

            if (playerState.passiveAction)
            {
                //Idle
                if (playerControl.controlIdle)
                {
                    actualAction = "Idle";
                    playerPhisic.PlayerHorizontalMoveFunction(0);
                    playerAnimation.ChangeAnimation("Anim_Player_01_Idle");
                }

                //Horizontal Movement Code
                if (playerControl.directionRight)
                {
                    rightSide = true;

                    if (playerControl.leftTrigger)
                    {
                        actualAction = "RunRight";
                        playerPhisic.PlayerHorizontalMoveFunction(playerStat.playerRunSpeed);
                        playerAnimation.ChangeAnimation("Anim_Player_03_Run");
                    }
                    else
                    {
                        actualAction = "WalkRight";
                        playerPhisic.PlayerHorizontalMoveFunction(playerStat.playerWalkSpeed);
                        playerAnimation.ChangeAnimation("Anim_Player_02_Walk");
                    }
                }

                if (playerControl.directionLeft)
                {
                    rightSide = false;

                    if (playerControl.leftTrigger)
                    {
                        actualAction = "RunLeft";
                        playerPhisic.PlayerHorizontalMoveFunction(-playerStat.playerRunSpeed);
                        playerAnimation.ChangeAnimation("Anim_Player_03_Run");
                    }
                    else
                    {
                        actualAction = "WalkLeft";
                        playerPhisic.PlayerHorizontalMoveFunction(-playerStat.playerWalkSpeed);
                        playerAnimation.ChangeAnimation("Anim_Player_02_Walk");
                    }
                }

            }
        }

        //Jump
        if (playerControl.button3 && totalJumps > 0)
        {
            actualAction = "Jump";
            playerPhisic.PlayerVerticalMoveFunction(playerStat.playerJumpForce);
            playerAnimation.ChangeAnimation("Anim_Player_04_Jump");
            totalJumps--;
            playerState.cancelableAction = true;
        }

        if(actualAction == "Jump")
        {
            if(playerAnimation.AnimationFinished("Anim_Player_04_Jump"))
            {
                actualAction = "Fall";
                playerAnimation.ChangeAnimation("Anim_Player_07_Fall");
                playerState.passiveAction = true;
            }
        }
    }
}
