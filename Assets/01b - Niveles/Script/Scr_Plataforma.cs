using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Plataforma : MonoBehaviour
{
    private Collider platformCollider;
    private GameObject player;

    void Start()
    {
        platformCollider = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player_Detect");
    }

    void Update()
    {
        // Verifica si el jugador está encima de la plataforma en el eje Y
        if (player.transform.position.y > transform.position.y )
        {
            Invoke("activarColision", 0.5f);

        }
        else
        {
            platformCollider.enabled = false;
        }
    }

    void activarColision()
    {
        platformCollider.enabled = true;
    }
}
