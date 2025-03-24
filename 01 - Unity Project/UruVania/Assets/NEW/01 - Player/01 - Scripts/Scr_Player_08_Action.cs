using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static Scr_Player_06_Combat;

public class Scr_Player_08_Action : MonoBehaviour
{
    //Script Variables
    private Scr_Player_01_Control playerControl;
    private Scr_Player_02_State playerState;
    private Scr_Player_05_Movement playerMovement;
    private Scr_Player_04_Physics playerPhysics;
    private Scr_Player_06_Combat playerCombat;
    private Scr_Player_07_Interaction playerInteraction;
    private Scr_Player_09_Animation playerAnimation;

    //Basic Variables
    public string actualAction;
    [HideInInspector] public bool rightSide;

    //Neccesary Action Data
    public class ActionData
    {
        public string Name;
        public string Animation;

        public Action<ActionData> State1;
        public Action<ActionData> State2;
        public void ApplyState()
        {
            State1?.Invoke(this);
            State2?.Invoke(this);
        }

        public float VelocityX;
        public float VelocityY;
    }

    //Awake is the first thing to update
    void Awake()
    {
        playerControl = GetComponent<Scr_Player_01_Control>();
        playerState = GetComponent<Scr_Player_02_State>();
        playerPhysics = GetComponent<Scr_Player_04_Physics>();
        playerMovement = GetComponent<Scr_Player_05_Movement>();
        playerCombat = GetComponent<Scr_Player_06_Combat>();
        playerInteraction = GetComponentInChildren<Scr_Player_07_Interaction>();
        playerAnimation = GetComponentInChildren<Scr_Player_09_Animation>();
    }

    //Update is called once per frame
    void Update()
    {
        #region//Priority Action 1 Obligatory stuff

        //Reset state after animation
        HandleStateFunction();

        playerInteraction.HandleHitInteraction();

        //Player Land 
        playerMovement.HandleMovementLand();

        #endregion

        #region//Priority Action 2 Attacks

        //Ground Attack code
        playerCombat.HandleGroundAttacksFunction();

        //Charge Attacks code
        playerCombat.HandleChargeAttackFunction();

        //Move Attack code
        playerCombat.HandleMovementAttackFunction();

        //Air Attacks code
        playerCombat.HandleAirAttackFunction();
        #endregion

        #region//Priority Action 3 Movement

        //Handle the Jump actions
        playerMovement.HandleMovementJump();

        //Movement in the Ground
        playerMovement.HandleMovementGrounded();
        #endregion
    }

    public void HandleActionFunction(ActionData playerAction)
    {
        actualAction = playerAction.Name;

        playerAnimation.ChangeAnimationFunction(playerAction.Animation);

        playerAction.ApplyState();

        if (playerAction.VelocityX != 0)
            playerPhysics.PlayerHorizontalMoveFunction(playerAction.VelocityX * (rightSide ? 1 : -1));

        if(playerAction.VelocityY != 0)
            playerPhysics.PlayerVerticalMoveFunction(playerAction.VelocityY);

        if (playerState.stateGrounded && playerAction.VelocityX == 0 && playerAction.VelocityY == 0)
            playerPhysics.PlayerStopMovementFunction();
    }

    //Change of state function
    private void ResetStateFunction(string animationName)
    {
        if (playerAnimation.AnimationEventFunction(animationName, 0.95f))
        {
            playerState.passiveAction = true;

            playerCombat.ResetAttackFunction();

            playerInteraction.ResetInteractionFunction();
        }
    }

    //manages various extra components
    private void HandleStateFunction()
    {
        //list of animations that need a reset at the end
        string[] attackAnimations =
        {
            "Animation_Jump",
            "Animation_DoubleJump",
            "Animation_Land",

            "Animation_NormalAttack1",
            "Animation_NormalAttack2",
            "Animation_NormalChargeAttack",
            "Animation_NormalJumpAttack",
            "Animation_NormalDashAttack",

            "Animation_PonchoAttack",
            "Animation_PonchoChargeAttack",
            "Animation_PonchoJumpAttack",
            "Animation_Dodge",

            "Animation_GroundHit",
            "Animation_AirHit"
        };

        foreach (string animation in attackAnimations)
        {
            ResetStateFunction(animation);
        }

        //Controls the pplayer direction
        if (playerState.stateGrounded)
        {
            if (playerControl.directionRight)
            {
                rightSide = true;
            }
            else if (playerControl.directionLeft)
            {
                rightSide = false;
            }
        }
    }
}
