using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_11_HurtBox : MonoBehaviour
{
    //Components Variables
    public bool playerIsHit = false;
    private int enemyLayer;

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
