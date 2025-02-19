using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Scr_Player_Life : MonoBehaviour
{
    public float actualLife;
    private float totalLife;
    public Image liferBar;

    public float actualMagic;
    private float totalMagic;
    public Image magicBar;

    void Start()
    {
        totalLife = actualLife;
        totalMagic = actualMagic;
    }

    // Update is called once per frame
    void Update()
    {
        liferBar.fillAmount = actualLife / totalLife;
        magicBar.fillAmount = actualMagic / totalMagic;

        actualLife = Mathf.Clamp(actualLife, 0f, totalLife);
        actualMagic = Mathf.Clamp(actualMagic, 0f, totalMagic);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto_Life"))
        {
            addLife(20);
        }

        if (collision.gameObject.CompareTag("Objeto_Magic"))
        {
            addMagic(15);
        }
    }

    public void addLife(float amount)
    {
        actualLife += amount;
    }

    public void addMagic(float amount)
    {
        actualMagic += amount;
    }
}
