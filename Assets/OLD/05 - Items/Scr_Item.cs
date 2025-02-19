using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Item : MonoBehaviour
{
    private Scr_Audio_Destroy audioEffect;

    private void Start()
    {
        audioEffect = GetComponent<Scr_Audio_Destroy>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            audioEffect.DestroyEffect();
        }
    }
}
