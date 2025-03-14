using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_3_Proyectile : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private Transform objetivo;
    public CapsuleCollider capsule1;
    public CapsuleCollider capsule2;

    public float velocityX;
    public float velocityY;
    public float velocidadRotacion;
    private bool destroy;
    private float tiempoRegresivo = 5f;
    private Scr_Enemy_Audio enemyAudio;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        objetivo = GameObject.FindWithTag("Player").transform;
        enemyAudio = GetComponent<Scr_Enemy_Audio>();

        if (objetivo.position.x < transform.position.x)
        {
            rigidBody.velocity = new Vector3(velocityX, velocityY, rigidBody.velocity.z);
        }

        if (objetivo.position.x > transform.position.x)
        {
            rigidBody.velocity = new Vector3(-velocityX, velocityY, rigidBody.velocity.z);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
        
        if(destroy)
        {
            tiempoRegresivo -= Time.deltaTime;
        }

        if (tiempoRegresivo <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Romper();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            Romper();
        }
    }

    public void Romper()
    {
        enemyAudio.DeathEffect();
        animator.Play("anim_enemy3_proyectile_2");
        capsule1.enabled = false;
        capsule2.enabled = false;
        destroy = true;
    }
}
