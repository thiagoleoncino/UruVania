using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Scr_Player_Magic : MonoBehaviour
{
    public Transform position;
    public bool enoughMagic;
    public bool noItem;
    
    public bool itemAxe;
    public GameObject axePrefabAxe;
    private Scr_Item_Axe axeScrpit;

    private Scr_Player_Life barScript;
    private Animator uiAnimator;

    void Start()
    {
        barScript = GetComponent<Scr_Player_Life>();
        axeScrpit = axePrefabAxe.GetComponent<Scr_Item_Axe>();
        uiAnimator = GameObject.FindWithTag("UI_Item").GetComponent<Animator>();
    }

    private void Update()
    {
        if(noItem)
        {
            uiAnimator.Play("Anim_UI_Item_N1");
            
            itemAxe = false;
        }

        if(itemAxe)
        {
            uiAnimator.Play("Anim_UI_Item_N2");

            if (barScript.actualMagic >= axeScrpit.necessaryMagic)
            {
                enoughMagic = true;
            }
            else { enoughMagic = false; }

            noItem = false;
        }

    }

    public void UseItem()
    {
        if (itemAxe)
        {
            GameObject newAxe = Instantiate(axePrefabAxe, position.position, Quaternion.Euler(0, 0, 45));
            barScript.actualMagic -= axeScrpit.necessaryMagic;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objeto_Axe"))
        {
            itemAxe = true;
            noItem = false;
            barScript.addMagic(20);
        }
    }
}
