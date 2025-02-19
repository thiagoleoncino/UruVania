using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Movement : MonoBehaviour
{
    // Movement Bools
    public bool playerCanMove;
    public bool playerIsGrounded;
    public bool playerIsDamage;
    public bool IsGrounded() //Grounded Bool Function
    {
        Vector3 center = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + 0.14f, capsuleCollider.bounds.center.z);
        Vector3 halfExtents = new Vector3(0.3f, 0.15f, 0f);
        return Physics.CheckBox(center, halfExtents, capsuleCollider.transform.rotation, groundLayerMask);
    }

    // Movement Stats
    [Space]
    public float walkVelocity;
    public float runVelocity;
    public float jumpForce;
    public float moveDirection;

    //Movement Components
    [HideInInspector]
    public Rigidbody rigidBody;
    private CapsuleCollider capsuleCollider;
    [Space]
    public LayerMask groundLayerMask;
    public Vector3 halfExtents;
    private Scr_Player_Life playerHealth;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerHealth = GetComponent<Scr_Player_Life>();
        playerCanMove = true;
    }

    private void Update()
    {
        playerIsGrounded = IsGrounded();

        if (playerIsGrounded && playerCanMove)
        {
            //Horizontal Movement
            moveDirection = Input.GetAxisRaw("Horizontal");

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerIsDamage)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        else
        {
            if (IsGrounded())
            {
                if (playerCanMove)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        rigidBody.velocity = new Vector3(runVelocity * moveDirection, rigidBody.velocity.y, rigidBody.velocity.z);
                    }
                    else
                    {
                        rigidBody.velocity = new Vector3(walkVelocity * moveDirection, rigidBody.velocity.y, rigidBody.velocity.z);
                    }
                }

                if (!playerCanMove)
                {
                    rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
                }
            }
        }
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
    }

    public void Damage(float damage, float knockbackX, float knockbackY, Vector3 knockbackDirection)
    {
        // Aplicar el knockback en la dirección opuesta al golpe
        rigidBody.velocity = new Vector3(knockbackDirection.x * knockbackX, knockbackY, rigidBody.velocity.z);

        playerHealth.actualLife -= damage;
        playerIsDamage = true;
    }
}
