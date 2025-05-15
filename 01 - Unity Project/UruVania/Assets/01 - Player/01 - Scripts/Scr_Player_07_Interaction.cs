using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_Enemy_01_BasicFunctions;

public class Scr_Player_07_Interaction : MonoBehaviour
{
    //Script Variables
    private Scr_Player_02_State playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_04_Physics playerPhysics;
    private Scr_Player_08_Action playerAction;
    private Scr_Player_09_Animation playerAnimations;
    private Scr_Player_11_HurtBox playerHurtBox;

    //Basic Variables
    public float actualDamage;
    public float actualKnockbackX;
    public float actualKnockbackY;

    //Awake is the first thing to update
    void Awake()
    {
        playerState = GetComponent<Scr_Player_02_State>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
        playerPhysics = GetComponent<Scr_Player_04_Physics>();
        playerAction = GetComponent<Scr_Player_08_Action>();
        playerAnimations = GetComponentInChildren<Scr_Player_09_Animation>();
        playerHurtBox = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent< Scr_Player_11_HurtBox>();
    }

    //Update is called once per frame
    void Update()
    {
        //Handle enemy collision
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Layer_Player"), LayerMask.NameToLayer("Layer_Enemy"), playerState.invulnerableCombatAction);
    }

    //Hit Interaction Function
    public void HandleHitInteraction()
    {
        if (playerHurtBox.playerIsHit)
        {
            // Aplica daño y knockback
            playerStatistics.playerActualLife -= playerHurtBox.enemyAttackDamage;
            actualDamage = playerHurtBox.enemyAttackDamage;
            actualKnockbackX = playerHurtBox.enemyAttackKnockbackX;
            actualKnockbackY = playerHurtBox.enemyAttackknockbackY;

            // Ejecutar animación correspondiente
            if (playerState.stateGrounded)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "Ground Hit",
                    Animation = "Animation_GroundHit",
                    State1 = (action) => playerState.noCancelableAction = true,
                    State2 = (action) => playerState.damageCombatAction = true,
                    VelocityX = -actualKnockbackX,
                });
            }
            if (playerState.stateAirborn)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "Air Hit",
                    Animation = "Animation_AirHit",
                    State1 = (action) => playerState.noCancelableAction = true,
                    State2 = (action) => playerState.damageCombatAction = true,
                    VelocityX = -actualKnockbackX,
                    VelocityY = actualKnockbackY
                });
            }

            // Reset data
            playerHurtBox.playerIsHit = false;
            playerHurtBox.enemyAttackDamage = 0;
            playerHurtBox.enemyAttackKnockbackX = 0;
            playerHurtBox.enemyAttackknockbackY = 0;
        }
    }

    //Resets various interaction components
    public void ResetInteractionFunction()
    {
        playerState.normalCombatAction = true;
    }

}
