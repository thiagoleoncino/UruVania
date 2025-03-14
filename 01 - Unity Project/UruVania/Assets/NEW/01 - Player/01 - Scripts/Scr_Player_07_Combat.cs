using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_07_Combat : MonoBehaviour
{
    private Scr_Player_01_Controls playerControl;
    private Scr_Player_02_States playerState;
    private Scr_Player_03_Statistics playerStat;
    private Scr_Player_04_Physics playerPhisic;
    private Scr_Player_05_Actions playerAction;
    private Scr_Player_06_Animations playerAnimation;
    private Scr_Player_08_Hitbox playerHitbox;

    public string actualAttack;

    public int attackCount;
    public bool attackCanBeCancel;


    void Awake()
    {
        playerControl = GetComponentInParent<Scr_Player_01_Controls>();
        playerState = GetComponentInParent<Scr_Player_02_States>();
        playerStat = GetComponentInParent<Scr_Player_03_Statistics>();
        playerPhisic = GetComponentInParent<Scr_Player_04_Physics>();
        playerAction = GetComponentInParent<Scr_Player_05_Actions>();
        playerAnimation = GetComponent<Scr_Player_06_Animations>();
        playerHitbox = GetComponentInChildren<Scr_Player_08_Hitbox>();
    }

    void Update()
    {
        // Passive Actions
        if (playerState.passiveAction)
        {
            // Actions in the Ground
            if (playerState.stateGrounded)
            {
                if (playerControl.button4Tap)
                {
                    Attack("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button4Hold)
                {
                    Attack("ChargeNormalAttack", "Anim_Player_11_NormalChargeAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button1Tap)
                {
                    Attack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button1Hold)
                {
                    Attack("ChargePonchoAttack", "Anim_Player_16_PonchoChargeAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }
            }
        }

        // Semi Cancelable Action (Combo code)
        if(playerState.semiCancelableAction)
        {
            //If the attack can be cancel and we hit an enemy
            if(attackCanBeCancel && playerHitbox.enemyDetected)
            {

                if (playerControl.button4Tap)
                {
                    Attack("NormalAttack2", "Anim_Player_09_NormalAttack2", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button4Hold)
                {
                    Attack("ChargeNormalAttack", "Anim_Player_11_NormalChargeAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button1Tap)
                {
                    Attack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }

                if (playerControl.button1Hold)
                {
                    Attack("ChargePonchoAttack", "Anim_Player_16_PonchoChargeAttack", 0, 0);
                    return; // Evita que se ejecuten otras acciones en el mismo frame
                }


                /*/Normal Attack Combo Tree
                if(actualAttack == "NormalAttack1")
                {
                    if (playerControl.button4Tap)
                    {
                        Attack("NormalAttack2", "Anim_Player_09_NormalAttack2", 0, 0);
                        return; // Evita que se ejecuten otras acciones en el mismo frame
                    }

                    if (playerControl.button4Hold)
                    {
                        Attack("ChargeNormalAttack", "Anim_Player_11_NormalChargeAttack", 0, 0);
                        return; // Evita que se ejecuten otras acciones en el mismo frame
                    }
                } */

            }
        }
    }

    public void Attack(string attackName, string animationName, float velX, float velY)
    {
        actualAttack = attackName;
        playerAction.actualAction = attackName;
        playerAnimation.ChangeAnimation(animationName);
        playerState.semiCancelableAction = true;
        playerPhisic.PlayerHorizontalMoveFunction(velX);
        playerPhisic.PlayerVerticalMoveFunction(velY);
    }

    public void EventAttackCanBeCancel()
    {
        attackCanBeCancel = true;
    }

    public void EventFinishAttack()
    {
        playerState.passiveAction = true;
        attackCanBeCancel = false;
        playerHitbox.enemyDetected = false;
    }
   
}
