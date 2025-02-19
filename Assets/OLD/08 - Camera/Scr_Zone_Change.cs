using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Scr_Zone_Change : MonoBehaviour
{
    public bool changeZone;
    public bool bossZone;
    public Scr_Follow_Manager followScript;
    public Scr_Player_Movement playerScript;
    public Animator bossAnimator;
    public Animator playerAnimator;
    private Scr_Scene_Manager musicScript;

    public SpriteRenderer lifebar1;
    public Image lifebar2;


    private void Start()
    {
        musicScript = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<Scr_Scene_Manager>();
        bossAnimator.speed = 0f;
        lifebar1.enabled = false;
        lifebar2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterZone();
        }
    }

    public void enterZone()
    {
        changeZone = true;
        followScript.bossCamara = true;

        if(bossZone)
        {
            playerScript.playerCanMove = false;
            playerAnimator.speed = 0f;
            Invoke("activateBoss", 1f);
            Invoke("activatePlayer", 3f);
            musicScript.stopMusic();
        }
    }

    public void activateBoss()
    {
        bossAnimator.speed = 1f;
        lifebar1.enabled = true;
        lifebar2.enabled = true;
    }

    public void activatePlayer()
    {
        playerAnimator.speed = 1f;
        playerScript.playerCanMove = true;
        Destroy(gameObject);
    }
}
