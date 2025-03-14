using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_2 : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidBody;
    private Scr_Enemy_Life enemyLife;
    private Scr_Enemy_Audio enemyAudio;
    public bool act;

    public float velocity;
    public float verticalSpeed = 1.0f;
    public float verticalRange = 1.0f; 
    private float startY;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<Scr_Enemy_Audio>();
        startY = transform.position.y;
        enemyLife = GetComponentInChildren<Scr_Enemy_Life>();

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
            float newY = startY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
        }

        if (enemyLife.life <= 0)
        {
            enemyLife.deathEffect();
            enemyAudio.DeathEffect();
            act = false;
            Destroy(gameObject);
        }
    }
}
