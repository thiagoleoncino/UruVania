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
        if (playerState.passiveAction)
        {
            if (playerState.stateGrounded)
            {
                if (playerControl.button4Tap)
                {
                    Attack("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0);
                    normalAttack1UsedInCombo = true; // Marcamos que NormalAttack1 fue usado
                    return;
                }

                if (playerControl.button4Hold)
                {
                    Attack("ChargeNormalAttack", "Anim_Player_11_NormalChargeAttack", 0, 0);
                    return;
                }

                if (playerControl.button1Tap)
                {
                    Attack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                    return;
                }

                if (playerControl.button1Hold)
                {
                    Attack("ChargePonchoAttack", "Anim_Player_16_PonchoChargeAttack", 0, 0);
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
                    Attack("NormalAttack2", "Anim_Player_09_NormalAttack2", 0, 0);
                }
                else
                {
                    Attack("NormalAttack1", "Anim_Player_08_NormalAttack1", 0, 0); // Si no, ejecuta NormalAttack1 primero
                    normalAttack1UsedInCombo = true;
                }

                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button4Hold)
            {
                Attack("ChargeNormalAttack", "Anim_Player_11_NormalChargeAttack", 0, 0);
                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button1Tap)
            {
                Attack("PonchoAttack", "Anim_Player_14_PonchoAttack", 0, 0);
                attackCanBeCancel = false;
                return;
            }

            if (playerControl.button1Hold)
            {
                Attack("ChargePonchoAttack", "Anim_Player_16_PonchoChargeAttack", 0, 0);
                attackCanBeCancel = false;
                return;
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

        comboCount++; // Incrementa el contador de combos correctamente
        Debug.Log("Combo Count: " + comboCount); // Depuración para ver el valor real de comboCount

        if (comboCount >= maxCombo)
        {
            attackCanBeCancel = false; // Bloquea el cancel después de 3 ataques
        }
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
}