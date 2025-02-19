using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_2_Detect : MonoBehaviour
{
    private Scr_Enemy_2 script;

    private void Start()
    {
        script = GetComponentInParent<Scr_Enemy_2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.act = true;
        }
    }
}
