using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_4_Detect_1 : MonoBehaviour
{
    private Scr_Enemy_4 script;

    private void Start()
    {
        script = GetComponentInParent<Scr_Enemy_4>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            script.act_1 = false;
            script.act_2 = true;
            script.act_3 = false;
        }
    }
}
