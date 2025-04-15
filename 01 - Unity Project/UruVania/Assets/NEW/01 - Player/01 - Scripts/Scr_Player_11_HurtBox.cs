using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_11_HurtBox : MonoBehaviour
{
    //Components Variables
    public bool playerIsHit = false;
    private int enemyLayer;
    public float attackDamage;
    [HideInInspector] public float knockbackX;
    [HideInInspector] public float knockbackY;

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
                attackDamage = enemyScript.passiveDamage;
                knockbackX = enemyScript.passiveKnocbackX;
                knockbackY = enemyScript.passiveKnocbackY;
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
