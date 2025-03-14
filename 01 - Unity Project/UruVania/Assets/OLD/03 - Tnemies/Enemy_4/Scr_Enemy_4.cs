using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_4 : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    private Rigidbody rigidBody;
    private CapsuleCollider capsule;
    private SpriteRenderer spriteRenderer;
    private Transform objetivo;
    private Scr_Enemy_Life enemyLife;
    private Scr_Enemy_Audio enemyAudio;

    public float velocity_1;
    public float velocity_2;

    public bool act_1;
    public bool act_2;
    public bool act_3;

    void Start()
    {
        InitializeComponents();
        InitializeVariables();
        AdjustVelocitiesBasedOnRotation();
        enemyAudio = GetComponent<Scr_Enemy_Audio>();
    }

    void InitializeComponents()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        enemyLife = GetComponentInChildren<Scr_Enemy_Life>();
    }

    void InitializeVariables()
    {
        act_1 = true;
        act_2 = false;
        act_3 = false;
    }

    void AdjustVelocitiesBasedOnRotation()
    {
        if (Mathf.Approximately(transform.rotation.eulerAngles.y, 180f))
        {
            velocity_1 = -velocity_1;
            velocity_2 = -velocity_2;
        }
    }

    void Update()
    {
        if (enemyLife.life > 0)
        {
            if (act_1)
            {
                Move(velocity_1, "anim_enemy4_walk");
            }
            else if (act_2)
            {
                Move(velocity_2, "anim_enemy4_dash");
            }
            else if (act_3)
            {
                Move(0, "anim_enemy4_attack");
                AlignRotationToPlayer();
            }
        }
        else
        {
            HandleEnemyDeath();
        }
    }

    void Move(float velocity, string animation)
    {
        rigidBody.velocity = new Vector3(velocity, rigidBody.velocity.y, rigidBody.velocity.z);
        animator.Play(animation);
    }

    void AlignRotationToPlayer()
    {
        transform.rotation = Quaternion.Euler(0f, (objetivo.position.x < transform.position.x) ? 180f : 0f, 0f);
    }

    void HandleEnemyDeath()
    {
        act_1 = false;
        act_2 = false;
        act_3 = false;
        capsule.enabled = false;
        enemyLife.deathEffect();
        enemyAudio.DeathEffect();
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Edge") || collision.gameObject.CompareTag("Enemy"))
        {
            RotateEnemy();
        }
    }

    void RotateEnemy()
    {
        velocity_1 = -velocity_1;
        velocity_2 = -velocity_2;
        float newRotationY = (Mathf.Approximately(transform.rotation.eulerAngles.y, 0f)) ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0f, newRotationY, 0f);
    }

    void backToWalk()
    {
        act_1 = false;
        act_2 = true;
        act_3 = false;
    }
}
