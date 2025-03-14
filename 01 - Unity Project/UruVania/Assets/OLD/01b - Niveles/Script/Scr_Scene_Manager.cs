using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Scene_Manager : MonoBehaviour
{
    private Scr_Player_Life playerLife;
    private AudioSource musicSource;
    public GameObject bossObject;

    public GameObject dropItem;
    public Vector3 dropPosition;
    private bool endOfLevel;

    public AudioClip bossTheme;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Scr_Player_Life>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(bossObject == null && !endOfLevel) 
        {
            Instantiate(dropItem, dropPosition, Quaternion.identity);
            endOfLevel = true;
        }

        if(playerLife.actualLife < 0)
        {
            stopMusic();
            Time.timeScale = 0.2f;
        }
    }

    public void stopMusic()
    {
        musicSource.Stop();
    }

    public void bossStart()
    {
        musicSource.clip = bossTheme;
        musicSource.Play();
    }
}
