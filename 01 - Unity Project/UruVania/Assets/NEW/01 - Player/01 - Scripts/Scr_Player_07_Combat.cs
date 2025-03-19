using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_07_Combat : MonoBehaviour
{
    //Scripts Variables
    private Scr_Player_01_Controls playerControl;
    private Scr_Player_02_States playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_04_Physics playerPhysics;
    private Scr_Player_05_Actions playerAction;
    private Scr_Player_06_Animations playerAnimation;
    private Scr_Player_08_Hitbox playerHitbox;

    //Basic Variables
    public string actualAttack;
    public bool attackCanBeCancel;
    private bool normalAttack1UsedInCombo = false;
    public bool normalAttackCharging;

    private bool canPerformGroundAction;
    private bool canPerformAirAction;

    //Neccesary Attack Data
    public struct AttackData
    {
        public string Name;
        public string Animation;
        public float VelocityX;
        public float VelocityY;
        public bool IsCombo;
    }

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Controls>();
        playerState = GetComponent<Scr_Player_02_States>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
        playerPhysics = GetComponent<Scr_Player_04_Physics>();
        playerAction = GetComponent<Scr_Player_05_Actions>();
        playerAnimation = GetComponentInChildren<Scr_Player_06_Animations>();
        playerHitbox = transform.GetChild(0).GetChild(0).GetComponent<Scr_Player_08_Hitbox>();
    }

    void Update()
    {
        //Track Player State
        DetectPlayerStateFunction();

        //Reset the Attack
        HandleAttackEnd();

        //Ground Attack code
        HandleGroundAttacksFunction();

        //Charge Attacks code
        HandleChargeAttackFunction();

        //Move Attack code
        HandleMovementAttackFunction();

        //Air Attacks code
        HandleAirAttackFunction();
    }

    #region//General Attack functions//---------------------------------------------------------------------------
    
    //Player State function
    private void DetectPlayerStateFunction()
    {
        //If player is in the ground
        canPerformGroundAction = playerState.passiveAction && playerState.stateGrounded;

        //If the player is in the air or Jumping
        canPerformAirAction = (playerState.passiveAction || playerState.cancelableAction) && playerState.stateAirborn;
    }

    //Singel Attack function
    private void PerformSingleAttackFunction(AttackData attack)
    {
        actualAttack = attack.Name;
        playerAction.actualAction = attack.Name;
        playerAnimation.ChangeAnimationFunction(attack.Animation);
        playerState.semiCancelableAction = true;
    }

    //Combo Attack function
    public void PerformComboAttackFunction(AttackData attack)
    {
        // Configurar ataque y animación
        PerformSingleAttackFunction(new AttackData
        {
            Name = attack.Name,
            Animation = attack.Animation
        });

        // Aplicar movimiento
        if (attack.VelocityX != 0)
            playerPhysics.PlayerHorizontalMoveFunction(attack.VelocityX * (playerAction.rightSide ? 1 : -1));

        if (attack.VelocityY != 0)
            playerPhysics.PlayerVerticalMoveFunction(attack.VelocityY);

        // Manejar el combo
        if (attack.IsCombo && playerStatistics.playerActualComboCount < playerStatistics.playerMaxCombo)
        {
            playerStatistics.playerActualComboCount++;
        }

        // Control de cancelación de ataques
        attackCanBeCancel = !attack.IsCombo && playerStatistics.playerActualComboCount < playerStatistics.playerMaxCombo;
    }

    #endregion

    #region//Reset Combat functions//-----------------------------------------------------------------------------

    //Resets various attack components
    private void ResetAttackFunction(string animationName)
    {
        if (playerAnimation.AnimationEventFunction(animationName, 0.95f))
        {
            playerState.passiveAction = true;
            attackCanBeCancel = false;
            playerHitbox.enemyDetected = false;
            normalAttack1UsedInCombo = false;
            
            playerStatistics.playerActualComboCount = 0;
            playerStatistics.playerActualChargeAmount = 0;
        }
    }

    //All actions that need to reset the components at the end
    private void HandleAttackEnd()
    {
        string[] attackAnimations =
        {
            "Animation_NormalAttack1",
            "Animation_NormalAttack2",
            "Animation_NormalChargeAttack",
            "Animation_NormalJumpAttack",
            "Animation_NormalDashAttack",

            "Animation_PonchoAttack",
            "Animation_PonchoChargeAttack",
            "Animation_PonchoJumpAttack",
            "Animation_Dodge"
        };

        foreach (string animation in attackAnimations)
        {
            ResetAttackFunction(animation);
        }
    }

    #endregion

    #region//Attack Functions//-----------------------------------------------------------------------------------

    //Handle the ground attacks
    public void HandleGroundAttacksFunction()
    {
        // Verifica si se puede hacer un combo
        bool canCombo = playerState.semiCancelableAction && attackCanBeCancel && playerHitbox.enemyDetected && playerStatistics.playerActualComboCount < playerStatistics.playerMaxCombo;

        // Si el jugador presiona el botón de ataque normal
        if (playerControl.button4Tap)
        {
            if (canCombo)
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = normalAttack1UsedInCombo ? "NormalAttack2" : "NormalAttack1",
                    Animation = normalAttack1UsedInCombo ? "Animation_NormalAttack2" : "Animation_NormalAttack1",
                    IsCombo = true,
                    VelocityX = 0
                });

                normalAttack1UsedInCombo = true;
                attackCanBeCancel = false;
            }
            else if (canPerformGroundAction)
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "NormalAttack1",
                    Animation = "Animation_NormalAttack1",
                    IsCombo = true,
                    VelocityX = 0
                });

                normalAttack1UsedInCombo = true;
            }

            return;
        }

        // Basic Poncho Attack
        if (playerControl.button1Tap && (canCombo || canPerformGroundAction))
        {
            PerformComboAttackFunction(new AttackData
            {
                Name = "PonchoAttack",
                Animation = "Animation_PonchoAttack",
                IsCombo = true,
                VelocityX = 0
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
                PerformComboAttackFunction(new AttackData
                {
                    Name = "NormalDashAttack",
                    Animation = "Animation_NormalDashAttack",
                    VelocityX = playerStatistics.playerDashSpeed,
                    IsCombo = false
                });
                return;
            }
            //Dodge
            else if (playerControl.button1)
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "NormalDodge",
                    Animation = "Animation_Dodge",
                    VelocityX = playerStatistics.playerDodgeSpeed,
                    IsCombo = false
                });
                playerState.noCancelableAction = true;
                return;
            }
        }
    }

    //Handle the attacks that can bee charge
    public void HandleChargeAttackFunction()
    {
        //Builds up the charge if the current attack is a charged attack
        bool isCharging = playerAction.actualAction == "ChargePonchoAttack" || playerAction.actualAction == "ChargeNormalAttack";
        if (isCharging) playerStatistics.playerActualChargeAmount += Time.deltaTime;

        if (canPerformGroundAction)
        {
            // Iniciar carga de ataque normal
            if (playerControl.button4Hold && playerStatistics.playerActualChargeAmount < playerStatistics.playerMaxChargeAttackTime)
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "ChargeNormalAttack",
                    Animation = "Animation_ChargingNormal",
                    IsCombo = false

                });
                return;
            }

            // Iniciar carga de ataque con poncho
            if (playerControl.button1Hold && playerStatistics.playerActualChargeAmount < playerStatistics.playerMaxChargeAttackTime)
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "ChargePonchoAttack",
                    Animation = "Animation_ChargingPoncho",
                    IsCombo = false
                });
                return;
            }
        }

        // Verifica si el jugador puede soltar un ataque cargado
        bool canReleaseCharge = playerState.semiCancelableAction && playerState.stateGrounded;

        if (canReleaseCharge)
        {
            // Liberar ataque cargado normal
            if (playerControl.button4Realase || (playerControl.button4Hold && playerStatistics.playerActualChargeAmount > playerStatistics.playerMaxChargeAttackTime))
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "ChargeAttackRealase",
                    Animation = "Animation_NormalChargeAttack",
                    IsCombo = false,
                    VelocityX = 0
                });
                return;
            }

            // Liberar ataque cargado con poncho
            if (playerControl.button1Realase || (playerControl.button1Hold && playerStatistics.playerActualChargeAmount > playerStatistics.playerMaxChargeAttackTime))
            {
                PerformComboAttackFunction(new AttackData
                {
                    Name = "ChargePonchoRealase",
                    Animation = "Animation_PonchoChargeAttack",
                    IsCombo = false,
                    VelocityX = 0
                });
                return;
            }
        }
    }

    //Handle the air attacks
    private void HandleAirAttackFunction()
    {
        if (canPerformAirAction)
        {
            //Jumping Normal Attack
            if (playerControl.button4)
            {
                PerformSingleAttackFunction(new AttackData
                {
                    Name = "NormalJumpAttack",
                    Animation = "Animation_NormalJumpAttack"
                });
                return;
            }

            //jumpong Poncho Attack
            else if (playerControl.button1)
            {
                PerformSingleAttackFunction(new AttackData
                {
                    Name = "PonchoJumpAttack",
                    Animation = "Animation_PonchoJumpAttack"
                });
                return;
            }
        }
    }
    
    #endregion
}