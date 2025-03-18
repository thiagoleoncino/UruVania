using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_07_Combat : MonoBehaviour
{
    //Scripts Variables
    private Scr_Player_01_Controls playerControl;
    private Scr_Player_02_States playerState;
    private Scr_Player_03_Statistics playerStat;
    private Scr_Player_04_Physics playerPhisic;
    private Scr_Player_05_Actions playerAction;
    private Scr_Player_06_Animations playerAnimation;
    private Scr_Player_08_Hitbox playerHitbox;

    //Basic Variables
    public string actualAttack;
    public bool attackCanBeCancel;

    [Space] //Combo Variables
    public int comboCount = 0;
    private const int maxCombo = 3;
    private bool normalAttack1UsedInCombo;

    [Space] //Attack Atributes Variables
    public bool playerCollision;
    public bool normalAttackCharge;
    public float chargeAmount;

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponentInParent<Scr_Player_01_Controls>();
        playerState = GetComponentInParent<Scr_Player_02_States>();
        playerStat = GetComponentInParent<Scr_Player_03_Statistics>();
        playerPhisic = GetComponentInParent<Scr_Player_04_Physics>();
        playerAction = GetComponentInParent<Scr_Player_05_Actions>();
        playerAnimation = GetComponent<Scr_Player_06_Animations>();
        playerHitbox = GetComponentInChildren<Scr_Player_08_Hitbox>();

        normalAttack1UsedInCombo = false;
    }

    void Update()
    {
        //Controls the Layers of Colision
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Layer_Player"), LayerMask.NameToLayer("Layer_Enemy"), playerCollision);

        //Reset the Attack
        HandleStateFunction();

        //Ground Attack code
        if (playerState.passiveAction && playerState.stateGrounded)
        {
            HandleGroundAttacksFunction(false);

            //Dash and Doge code
            if (playerControl.leftTrigger)
            {
                //Dash
                if(playerControl.button4)
                {
                    ComboAttackFunction("NormalDashAttack", "Anim_Player_13_NormalDashAttack", playerStat.playerDashSpeed, 0, false);
                    return;
                } 
                //Dodge
                else if (playerControl.button1)
                {
                    ComboAttackFunction("NormalDodge", "Anim_Player_18_Dodge", playerStat.playerDodgeSpeed, 0, false);
                    playerState.noCancelableAction = true;
                    playerCollision = true;
                    return;
                }
            }

        }

        //Charge Attacks code
        if (playerState.semiCancelableAction && playerState.stateGrounded)
        {
            //Realase Normal Charge Attack
            if (playerControl.button4Realase)
            {
                ComboAttackFunction("ChargeAttackRealase", "Anim_Player_11_NormalChargeAttack", 0, 0, false);
                return;
            }

            //Realase Poncho Charge Attack
            if (playerControl.button1Realase)
            {
                ComboAttackFunction("ChargePonchoRealase", "Anim_Player_16_PonchoChargeAttack", 0, 0, false);
                return;
            }
        }

        //Air Attacks code
        if ((playerState.passiveAction || playerState.cancelableAction) && playerState.stateAirborn)
        {
            HandleAirAttacksFunction();
        }

        //Combo Attack code
        if (playerState.semiCancelableAction && attackCanBeCancel && playerHitbox.enemyDetected && comboCount < maxCombo)
        {
            HandleGroundAttacksFunction(true);
        }

    }

    //General Attack function
    private void GeneralAttackFunction(string attackName, string animationName)
    {
        actualAttack = attackName;
        playerAction.actualAction = attackName;
        playerAnimation.ChangeAnimationFunction(animationName);
        playerState.semiCancelableAction = true;

    }

    //Combo Attacks function
    public void ComboAttackFunction(string attackName, string animationName, float velX, float velY, bool isComboAttack)
    {
        GeneralAttackFunction(attackName, animationName);

        playerPhisic.PlayerHorizontalMoveFunction(velX * (playerAction.rightSide ? 1 : -1));
        playerPhisic.PlayerVerticalMoveFunction(velY);

        comboCount++;

        if (comboCount >= maxCombo)
        {
            attackCanBeCancel = false;
        }

        if(isComboAttack)
        {
            attackCanBeCancel = false;
        }
    }

    //Handle the ground attacks
    public void HandleGroundAttacksFunction(bool secondAttackBool)
    {
        //Normal Attack 1-2 
        if (secondAttackBool)
        {
            if (playerControl.button4Tap)
            {
                //Attack 2
                if (normalAttack1UsedInCombo) 
                {
                    ComboAttackFunction("NormalAttack2", "Anim_Player_09_NormalAttack2", 0, 0, secondAttackBool);
                    attackCanBeCancel = false;
                }

                //Attack 1
                else
                {
                    ComboAttackFunction("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0, secondAttackBool);
                    normalAttack1UsedInCombo = true;
                    attackCanBeCancel = false;
                }

                return;
            }
        }
        else
        {
            //Attack 1
            if (playerControl.button4Tap)
            {
                ComboAttackFunction("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0, secondAttackBool);
                normalAttack1UsedInCombo = true;
                return;
            }
        }

        //Charge the charged normal attack 
        if (playerControl.button4Hold)
        {
            ComboAttackFunction("ChargeNormalAttack", "Anim_Player_10_ChargingNormal", 0, 0, secondAttackBool);
            chargeAmount += 0.1f;
            return;
        }

        //Basic Poncho Attack
        if (playerControl.button1Tap)
        {
            ComboAttackFunction("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0, secondAttackBool);
            return;
        }

        //Charge the poncho normal attack
        if (playerControl.button1Hold)
        {
            ComboAttackFunction("ChargePonchoAttack", "Anim_Player_15_ChargingPoncho", 0, 0, secondAttackBool);
            chargeAmount += 0.1f;
            return;
        }
    }

    //Handle the air attacks
    private void HandleAirAttacksFunction()
    {
        //Jumping Normal Attack
        if (playerControl.button4)
        {
            GeneralAttackFunction("NormalJumpAttack", "Anim_Player_12_NormalJumpAttack");
        }

        //jumpong Poncho Attack
        else if (playerControl.button1)
        {
            GeneralAttackFunction("PonchoJumpAttack", "Anim_Player_17_PonchoJumpAttack");
        }
    }

    //Resets various attack components
    private void ResetAttackFunction(string animationName)
    {
        if (playerAnimation.AnimationEventFunction(animationName, 0.95f))
        {
            playerState.passiveAction = true;
            attackCanBeCancel = false;
            playerHitbox.enemyDetected = false;
            comboCount = 0;
            normalAttack1UsedInCombo = false; 
        }
    }

    //All actions that need a change of state at the end
    private void HandleStateFunction()
    {
        ResetAttackFunction("Anim_Player_08_NormalAttack1");
        ResetAttackFunction("Anim_Player_09_NormalAttack2");
        ResetAttackFunction("Anim_Player_11_NormalChargeAttack");
        ResetAttackFunction("Anim_Player_12_NormalJumpAttack");
        ResetAttackFunction("Anim_Player_13_NormalDashAttack");
        ResetAttackFunction("Anim_Player_14_PonchoAttack");
        ResetAttackFunction("Anim_Player_16_PonchoChargeAttack");
        ResetAttackFunction("Anim_Player_17_PonchoJumpAttack");
        ResetAttackFunction("Anim_Player_18_Dodge");
    }

    //Animator Events

    //Indicates that the attack can be cancelled
    public void EventAttackCanBeCancel()
    {
        if (comboCount < maxCombo)
        {
            attackCanBeCancel = true;
        }
    }

    //Indicates that collisions are enabled
    public void EventActivateCollision()
    {
        playerCollision = false;
    }
}