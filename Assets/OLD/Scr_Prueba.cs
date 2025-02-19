using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Prueba : MonoBehaviour
{
    private Scr_Enemy_1 enemyScript;

    private void Start()
    {
       enemyScript = GetComponentInParent<Scr_Enemy_1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Edge")
        {
            enemyScript.Flip();
        }
    }
}
