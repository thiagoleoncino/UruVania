using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_1 : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    public BoxCollider flipCollider;
    private Rigidbody rigidBody;
    private CapsuleCollider capsule;
    private SpriteRenderer spriteRenderer;
    private Scr_Enemy_Life enemyLife;

    public bool act;
    public float velocity;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyLife = GetComponentInChildren<Scr_Enemy_Life>();
        animator.speed = 0f;

        if (Mathf.Approximately(transform.rotation.eulerAngles.y, 180f))
        {
            velocity = -velocity;
        }
    }

    void Update()
    {
        if (act)
        {
            rigidBody.velocity = new Vector3(-velocity, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
        }

        if (enemyLife.life <= 0)
        {
            animator.Play("anim_enemy1_death");
            act = false;
            capsule.enabled = false;
        }
    }

    public void Walk()
    {
        act = true;
        animator.Play("anim_enemy1_walk");
    }

    public void Death()
    {
        enemyLife.deathEffect();
        Destroy(gameObject);
    }

    public void Flip()
    {
        velocity = -velocity;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            Flip();
        }
    }
}
