using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

public class Scr_Player_06_Combat : MonoBehaviour
{
    //Scripts Variables
    private Scr_Player_01_Control playerControl;
    private Scr_Player_02_State playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_04_Physics playerPhysics;
    private Scr_Player_08_Action playerAction;
    private Scr_Player_10_HitBox playerHitbox;

    //Basic Variables
    public bool attackCanBeCancel;
    private bool normalAttack1UsedInCombo;
    public int playerMaxCombo = 3; //The maximum amount of attack we can perfomr in a combo
    public int playerActualComboCount = 0;
    [Space]
    public bool chargingAttack;
    public float playerMaxChargeAttackTime; //The maximum amount of time a charge attack can be charge
    public float playerActualChargeAmount = 0;

    private bool canPerformGroundAction;
    private bool canPerformAirAction;

    //Neccesary Attack Data
    public struct AttackData
    {
        public string Name;
        public string Animation;

        public bool State;
        public float VelocityX;
        public float VelocityY;

        public bool CanCombo;
    }

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Control>();
        playerState = GetComponent<Scr_Player_02_State>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
        playerPhysics = GetComponent<Scr_Player_04_Physics>();
        playerAction = GetComponentInChildren<Scr_Player_08_Action>();
        playerHitbox = transform.GetChild(0).GetChild(0).GetComponent<Scr_Player_10_HitBox>();
    }

    //Update is called once per frame
    void Update()
    {
        //Track Player State
        DetectPlayerStateFunction();
    }

    //Player State function
    private void DetectPlayerStateFunction()
    {
        //If player is in the ground
        canPerformGroundAction = playerState.passiveAction && playerState.stateGrounded;

        //If the player is in the air or Jumping
        canPerformAirAction = (playerState.passiveAction || playerState.cancelableAction) && playerState.stateAirborn;
    }

    //Player combo attack function
    private void PerformComboFunction(AttackData attack)
    {
        playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
        {
            Name = attack.Name,
            Animation = attack.Animation,
            State1 = (action) => playerState.semiCancelableAction = true,
            VelocityX = attack.VelocityX,
            VelocityY = attack.VelocityY
        });

        if (playerActualComboCount < playerMaxCombo)
        {
            playerActualComboCount++;
        }

        attackCanBeCancel = !attack.CanCombo && playerActualComboCount < playerMaxCombo;

    }

    //Handle the ground attacks
    public void HandleGroundAttacksFunction()
    {
        //Combo verification
        bool canCombo = playerState.semiCancelableAction && attackCanBeCancel && playerHitbox.enemyDetected && playerActualComboCount < playerMaxCombo;

        //Ground Normal Attack
        if (playerControl.button4Tap)
        {
            if (canCombo) //Manages the second normal attack
            {
                PerformComboFunction(new AttackData
                {
                    Name = normalAttack1UsedInCombo ? "NormalAttack2" : "NormalAttack1",
                    Animation = normalAttack1UsedInCombo ? "Animation_NormalAttack2" : "Animation_NormalAttack1",
                    CanCombo = true,
                });

                normalAttack1UsedInCombo = true;
                attackCanBeCancel = false;
            }
            else if (canPerformGroundAction) //Manages the first normal attack
            {
                PerformComboFunction(new AttackData
                {
                    Name = "NormalAttack1",
                    Animation = "Animation_NormalAttack1",
                    CanCombo = true,
                });

                normalAttack1UsedInCombo = true;
            }

            return;
        }

        //Ground Poncho Attack
        if (playerControl.button1Tap && (canCombo || canPerformGroundAction))
        {
            PerformComboFunction(new AttackData
            {
                Name = "PonchoAttack",
                Animation = "Animation_PonchoAttack",
                CanCombo = true,
            });
        }
    }

    //Handle the attacks that use movment
    public void HandleMovementAttackFunction()
    {
        if (canPerformGroundAction && playerControl.leftTrigger)
        {
            //Dash
            if (playerControl.button4)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "NormalDashAttack",
                    Animation = "Animation_NormalDashAttack",
                    State1 = (action) => playerState.semiCancelableAction = true,
                    VelocityX = playerStatistics.playerDashSpeed,
                });
                return;
            }
            //Dodge
            else if (playerControl.button1)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "NormalDodge",
                    Animation = "Animation_Dodge",
                    State1 = (action) => playerState.noCancelableAction = true,
                    VelocityX = playerStatistics.playerDodgeSpeed,
                });
                return;
            }
        }
    }

    //Handle the attacks that can bee charge
    public void HandleChargeAttackFunction()
    {
        //Builds up the charge if the current attack is a charged attack
        bool isCharging = playerAction.actualAction == "ChargePonchoAttack" || playerAction.actualAction == "ChargeNormalAttack";
        if (isCharging) playerActualChargeAmount += Time.deltaTime;

        if (canPerformGroundAction)
        {
            // Start normal attack charge
            if (playerControl.button4Hold && playerActualChargeAmount < playerMaxChargeAttackTime)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "ChargeNormalAttack",
                    Animation = "Animation_ChargingNormal",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }

            // Start poncho attack charge
            if (playerControl.button1Hold && playerActualChargeAmount < playerMaxChargeAttackTime)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "ChargePonchoAttack",
                    Animation = "Animation_ChargingPoncho",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }
        }

        //Checks if the player can release a charged attack
        bool canReleaseCharge = playerState.semiCancelableAction && playerState.stateGrounded;

        //Attack after the charge
        if (canReleaseCharge)
        {
            //Release normal charged attack
            if (playerControl.button4Realase || (playerControl.button4Hold && playerActualChargeAmount > playerMaxChargeAttackTime))
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "ChargeAttackRealase",
                    Animation = "Animation_NormalChargeAttack",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }

            //Release poncho charged attack
            if (playerControl.button1Realase || (playerControl.button1Hold && playerActualChargeAmount > playerMaxChargeAttackTime))
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "ChargePonchoRealase",
                    Animation = "Animation_PonchoChargeAttack",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }
        }
    }

    //Handle the air attacks
    public void HandleAirAttackFunction()
    {
        if (canPerformAirAction)
        {
            //Jumping Normal Attack
            if (playerControl.button4)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "NormalJumpAttack",
                    Animation = "Animation_NormalJumpAttack",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }

            //jumpong Poncho Attack
            else if (playerControl.button1)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "PonchoJumpAttack",
                    Animation = "Animation_PonchoJumpAttack",
                    State1 = (action) => playerState.semiCancelableAction = true,
                });
                return;
            }
        }
    }
    
    //Resets various attack components
    public void ResetAttackFunction()
    {
        attackCanBeCancel = false;
        normalAttack1UsedInCombo = false;
        playerHitbox.enemyDetected = false;

        playerActualComboCount = 0;
        playerActualChargeAmount = 0;
    }
}