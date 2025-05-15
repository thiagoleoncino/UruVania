using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_11_HurtBox : MonoBehaviour
{
    //Components Variables
    public bool playerIsHit = false;
    private int enemyLayer;
    [Space]
    public float enemyAttackDamage;
    public float enemyAttackKnockbackX;
    public float enemyAttackknockbackY;

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Layer_Enemy");
    }

    //Detection when entering the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            playerIsHit = true;

            Scr_Enemy_01_BasicFunctions enemyScript = other.GetComponent<Scr_Enemy_01_BasicFunctions>();
            if (enemyScript != null)
            {
                enemyAttackDamage = enemyScript.passiveDamage;
                enemyAttackKnockbackX = enemyScript.passiveKnocbackX;
                enemyAttackknockbackY = enemyScript.passiveKnocbackY;
            }

        }
    }

    //Detection when exiting the trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
           playerIsHit = false;
        }
    }
}