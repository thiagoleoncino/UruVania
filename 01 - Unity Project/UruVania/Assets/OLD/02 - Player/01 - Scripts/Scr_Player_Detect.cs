using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Detect : MonoBehaviour
{
    private Scr_Player_Movement playerScript;

    private void Start()
    {
        playerScript = GetComponentInParent<Scr_Player_Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EndZone")
        {
            Scr_Enemy_Damage enemyScript = other.gameObject.GetComponent<Scr_Enemy_Damage>();

            if (enemyScript != null)
            {
                float knockbackX = enemyScript.knockbackX;
                float knockbackY = enemyScript.knockbackY;
                float damage = enemyScript.damage;

                Vector3 knockbackDirection = transform.position - other.transform.position;
                knockbackDirection.Normalize();

                //playerScript.Damage(damage, knockbackX, knockbackY, knockbackDirection);
            }
        }
    }
}
