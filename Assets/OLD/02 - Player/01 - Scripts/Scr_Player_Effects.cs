using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Effects : MonoBehaviour
{
    public GameObject effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Objeto"))
        {
            Vector3 posicionDeColision = other.transform.position;
            Instantiate(effect, posicionDeColision, Quaternion.identity);
        }

    }
}
