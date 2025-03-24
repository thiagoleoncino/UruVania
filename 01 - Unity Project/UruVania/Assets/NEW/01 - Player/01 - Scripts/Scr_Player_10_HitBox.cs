using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_10_HitBox : MonoBehaviour
{
    //Components Variables
    public bool enemyDetected = false;
    private int enemyLayer;
   
    //Awake is the first thing to update
    void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Layer_Enemy");
    }

    //Detection when entering the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            enemyDetected = true;
        }
    }

}
