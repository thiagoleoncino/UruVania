using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Boss_1_Detect : MonoBehaviour
{
    private Scr_Boss_1 script;
    private bool onCooldown = false;
    public float cooldownDuration;
    public float cooldownTimer;

    void Start()
    {
        script = GetComponentInParent<Scr_Boss_1>();
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
        if (!onCooldown && other.gameObject.tag == "Player" && script.actualState == TipoAccion.action1)
        {
            script.actualState = TipoAccion.action2;
            onCooldown = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!onCooldown && other.gameObject.tag == "Player" && script.actualState == TipoAccion.action1)
        {
            script.actualState = TipoAccion.action2;
            onCooldown = true;
        }
    }
}
