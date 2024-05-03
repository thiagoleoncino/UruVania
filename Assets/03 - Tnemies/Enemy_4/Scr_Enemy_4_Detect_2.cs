using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_4_Detect_2 : MonoBehaviour
{
    private Scr_Enemy_4 script;

    private bool onCooldown = false;
    private float cooldownDuration = 3f;
    public float cooldownTimer;


    private void Start()
    {
        script = GetComponentInParent<Scr_Enemy_4>();
    }

    private void Update()
    {
        if (onCooldown)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= cooldownDuration)
            {
                onCooldown = false;
                cooldownTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onCooldown && other.gameObject.tag == "Player")
        {
            script.act_1 = false;
            script.act_2 = false;
            script.act_3 = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!onCooldown && other.gameObject.tag == "Player")
        {
            script.act_1 = false;
            script.act_2 = false;
            script.act_3 = true;
        }
    }
}
