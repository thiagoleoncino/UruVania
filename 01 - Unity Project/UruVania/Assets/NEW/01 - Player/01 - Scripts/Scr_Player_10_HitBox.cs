using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_10_HitBox : MonoBehaviour
{
    public bool enemyDetected = false;
    private int enemyLayer;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Layer_Enemy"); // Obtiene el índice de la capa
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            enemyDetected = true;
        }
    }

}
