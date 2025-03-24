using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_07_Interaction : MonoBehaviour
{
    //Script Variables
    private Scr_Player_02_State playerState;
    private Scr_Player_04_Physics playerPhysics;
    private Scr_Player_08_Action playerAction;
    private Scr_Player_09_Animation playerAnimations;
    private Scr_Player_11_HurtBox playerHurtBox;

    //Basic Variables
    public float baseKnockbackX;
    public float baseKnockbackY;

    //Awake is the first thing to update
    void Awake()
    {
        playerState = GetComponent<Scr_Player_02_State>();
        playerPhysics = GetComponent<Scr_Player_04_Physics>();
        playerAction = GetComponent<Scr_Player_08_Action>();
        playerAnimations = GetComponentInChildren<Scr_Player_09_Animation>();
        playerHurtBox = transform.GetChild(0).GetChild(1).GetComponent< Scr_Player_11_HurtBox>();
    }

    //Update is called once per frame
    void Update()
    {
        //Handle enemy collision
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Layer_Player"), LayerMask.NameToLayer("Layer_Enemy"), playerState.invulnerableCombatAction);
    }

    //Damage Interaction Function
    public void HandleHitInteraction()
    {
        if (playerHurtBox.playerIsHit)
        {
            //Ground Hit
            if (playerState.stateGrounded)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "Ground Hit",
                    Animation = "Animation_GroundHit",
                    State1 = (action) => playerState.noCancelableAction = true,
                    State2 = (action) => playerState.damageCombatAction = true,
                    VelocityX = -baseKnockbackX,
                });
            }

            //Air Hit
            if (playerState.stateAirborn)
            {
                playerAction.HandleActionFunction(new Scr_Player_08_Action.ActionData
                {
                    Name = "Air Hit",
                    Animation = "Animation_AirHit",
                    State1 = (action) => playerState.noCancelableAction = true,
                    State2 = (action) => playerState.damageCombatAction = true,
                    VelocityX = -baseKnockbackX,
                    VelocityY = baseKnockbackY
                });
            }
        }
    }

    //Resets various interaction components
    public void ResetInteractionFunction()
    {
        playerState.normalCombatAction = true;
    }

}
