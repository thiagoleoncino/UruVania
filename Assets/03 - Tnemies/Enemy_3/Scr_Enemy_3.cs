using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Scr_Enemy_3 : MonoBehaviour
{
    private Animator animator;
    public GameObject proyectile;
    public Transform position;
    private CapsuleCollider capsule;
    private Scr_Enemy_Life enemyLife;
    private Scr_Enemy_Audio enemyAudio;

    public bool act;
    private Transform objetivo;

    void Start()
    {
        animator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        objetivo = GameObject.FindWithTag("Player").transform;
        enemyLife = GetComponentInChildren<Scr_Enemy_Life>();
        enemyAudio = GetComponent<Scr_Enemy_Audio>();
    }

    void Update()
    {
        if(act)
        {
            animator.Play("anim_enemy3_attack");
        }

        if (enemyLife.life <= 0)
        {
            enemyLife.deathEffect();
            enemyAudio.DeathEffect();
            act = false;
            Destroy(gameObject);
            capsule.enabled = false;
        }

        if (objetivo.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (objetivo.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public void Proyectile()
    {
        Instantiate(proyectile, position.position, position.rotation);
    }

}
