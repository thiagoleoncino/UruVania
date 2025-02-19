using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_1_Detect : MonoBehaviour
{
    private Scr_Enemy_1 script;

    private void Start()
    {
        script = GetComponentInParent<Scr_Enemy_1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.animator.speed = 1f;
        }
    }
}
