using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Flip : MonoBehaviour
{
    public MonoBehaviour enemyScript;

    private void Start()
    {
        enemyScript = GetComponentInParent<Scr_Enemy_1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Edge")
        {
            //enemyScript.Flip();
        }
    }
}
