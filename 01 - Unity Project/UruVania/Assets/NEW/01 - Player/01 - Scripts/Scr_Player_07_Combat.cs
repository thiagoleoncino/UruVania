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
    public bool attackCanBeCancel;

    public int comboCount = 0;
    private const int maxCombo = 3;

    public bool playerCollision;
    public bool normalAttackCharge;
    public float chargeAmount;

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

    private bool normalAttack1UsedInCombo = false; // Para rastrear si se usó en este combo

    void Update()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Layer_Player"), LayerMask.NameToLayer("Layer_Enemy"), playerCollision);

        if (playerState.passiveAction)
        {
            if (playerState.stateGrounded)
            {
                if (playerControl.button4Tap)
                {
                    GroundAttack("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0);
                    normalAttack1UsedInCombo = true; // Marcamos que NormalAttack1 fue usado
                    return;
                }

                if (playerControl.button4Hold)
                {
                    ChargeAttack("ChargeNormalAttack", "Anim_Player_10_ChargingNormal");
                    return;
                }

                if (playerControl.button1Tap)
                {
                    GroundAttack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                    return;
                }

                if (playerControl.button1Hold)
                {
                    ChargeAttack("ChargePonchoAttack", "Anim_Player_15_ChargingPoncho");
                    return;
                }

                if (playerControl.leftTrigger && playerControl.button4)
                {
                    GroundAttack("NormalDashAttack", "Anim_Player_13_NormalDashAttack", playerStat.playerDashSpeed, 0);
                    return;
                }

                if (playerControl.leftTrigger && playerControl.button1)
                {
                    GroundAttack("NormalDodge", "Anim_Player_18_Dodge", playerStat.playerDodgeSpeed, 0);
                    playerCollision = true;
                    return;
                }
            }
        }

        if (playerState.passiveAction || playerState.cancelableAction)
        {
            if (playerState.stateAirborn)
            {
                if (playerControl.button4)
                {
                    AirAttack("NormalJumpAttack", "Anim_Player_12_NormalJumpAttack");
                    return;
                }

                if (playerControl.button1)
                {
                    AirAttack("PonchoJumpAttack", "Anim_Player_17_PonchoJumpAttack");
                    return;
                }
            }
        }


        if (playerState.semiCancelableAction && attackCanBeCancel && playerHitbox.enemyDetected && comboCount < maxCombo)
        {
            if (playerControl.button4Tap)
            {
                if (normalAttack1UsedInCombo) // Solo permite NormalAttack2 si NormalAttack1 fue usado en este combo
                {
                    GroundAttack("NormalAttack2", "Anim_Player_09_NormalAttack2", 0, 0);
                }
                else
                {
                    GroundAttack("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0); // Si no, ejecuta NormalAttack1 primero
                    normalAttack1UsedInCombo = true;
                }

                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button4Hold)
            {
                ChargeAttack("ChargeNormalAttack", "Anim_Player_10_ChargingNormal");
                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button1Tap)
            {
                GroundAttack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button1Hold)
            {
                ChargeAttack("ChargePonchoAttack", "Anim_Player_15_ChargingPoncho");
                attackCanBeCancel = false;
                return;
            }
        }

        if (playerControl.button1Realase)
        {
            GroundAttack("ChargePonchoRealase", "Anim_Player_16_PonchoChargeAttack", 0, 0);
            return;
        }

        if (playerControl.button4Realase)
        {
            GroundAttack("ChargeAttackRealase", "Anim_Player_11_NormalChargeAttack", 0, 0);
            return;
        }
    }

    public void GroundAttack(string attackName, string animationName, float velX, float velY)
    {
        actualAttack = attackName;
        playerAction.actualAction = attackName;
        playerAnimation.ChangeAnimation(animationName);
        playerState.semiCancelableAction = true;

        if (playerAction.rightSide)
        {
            playerPhisic.PlayerHorizontalMoveFunction(velX);
        } else { playerPhisic.PlayerHorizontalMoveFunction(-velX); }

        playerPhisic.PlayerVerticalMoveFunction(velY);

        comboCount++; // Incrementa el contador de combos correctamente
        Debug.Log("Combo Count: " + comboCount); // Depuración para ver el valor real de comboCount

        if (comboCount >= maxCombo)
        {
            attackCanBeCancel = false; // Bloquea el cancel después de 3 ataques
        }
    }

    public void AirAttack(string attackName, string animationName)
    {
        actualAttack = attackName;
        playerAction.actualAction = attackName;
        playerAnimation.ChangeAnimation(animationName);
        playerState.semiCancelableAction = true;
    }

    public void ChargeAttack(string attackName, string animationName)
    {
        actualAttack = attackName;
        playerAction.actualAction = attackName;
        playerAnimation.ChangeAnimation(animationName);
        playerState.semiCancelableAction = true;
        chargeAmount += 0.1f;
    }

    public void EventAttackCanBeCancel()
    {
        if (comboCount < maxCombo)
        {
            attackCanBeCancel = true;
        }
    }

    public void EventFinishAttack()
    {
        playerState.passiveAction = true;
        attackCanBeCancel = false;
        playerHitbox.enemyDetected = false;
        comboCount = 0; // Reinicia el contador cuando termina la animación
        normalAttack1UsedInCombo = false; // Reinicia el estado de NormalAttack1 en el combo
    }

    public void EventDisableCollision()
    {
        playerCollision = true;
    }

    public void EventActivateCollision()
    {
        playerCollision = false;
    }

}