using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_07_Interaction : MonoBehaviour
{
    //Variables
    private int enemyLayer;
    private string actualAnimation;

    public bool playerIsHit;
    public int hitCount;

    private Scr_Player_02_State playerState;
    private Scr_Player_04_Physics playerPhysics; 
    private Scr_Player_09_Animation playerAnimations;


    void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Layer_Enemy");
        playerState = GetComponentInParent<Scr_Player_02_State>();
        playerPhysics = GetComponentInParent<Scr_Player_04_Physics>();
        playerAnimations = GetComponent<Scr_Player_09_Animation>();
    }

    private void Update()
    {
        if (playerState.stateGrounded && playerIsHit)
        {
            playerAnimations.ChangeAnimationFunction("Animation_GroundHit");
            playerState.noCancelableAction = true;
        }

        if (playerState.stateAirborn && playerIsHit)
        {
            playerAnimations.ChangeAnimationFunction("Animation_AirHit");
            playerState.noCancelableAction = true;
        }

        if (playerAnimations.AnimationEventFunction(("Animation_GroundHit"), 0.95f) 
            || playerAnimations.AnimationEventFunction(("Animation_AirHit"), 0.95f))
        {
            playerIsHit = false;
            playerState.passiveAction = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            playerIsHit = true;
            hitCount++; // Incrementa el contador de golpes
            playerPhysics.PlayerHorizontalMoveFunction(-5f);

            // Si el enemigo ya está en la animación de daño, reiniciar la animación
            if (actualAnimation == "Animation_GroundHit")
            {
                playerAnimations.ChangeAnimationFunction("Animation_GroundHit");
            }
        }
    }

}
