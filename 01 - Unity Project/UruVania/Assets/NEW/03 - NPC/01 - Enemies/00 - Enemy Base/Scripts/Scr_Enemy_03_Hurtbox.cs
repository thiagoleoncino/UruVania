using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_03_Hurtbox : MonoBehaviour
{
    //Variables
    private int playerHitboxLayer;
    private Scr_Enemy_01_BasicFunctions enemyState;

    // Start is called before the first frame update
    void Start()
    {
        playerHitboxLayer = LayerMask.NameToLayer("Layer_PlayerHitbox");
        enemyState = GetComponentInParent<Scr_Enemy_01_BasicFunctions>();
    }

    //Player Hitbox Detection
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerHitboxLayer && enemyState.enemyActualLifeAmount > 0)
        {
            Scr_Player_10_HitBox playerScript = other.GetComponent<Scr_Player_10_HitBox>();
            if (playerScript != null)
            {
                enemyState.enemyKnockbackX = playerScript.hitboxKnocbackX;
                enemyState.enemyKnockbackY = playerScript.hitboxKnocbackY;
            }

            enemyState.EnemyHitFunction(other);
        }
    }
}
