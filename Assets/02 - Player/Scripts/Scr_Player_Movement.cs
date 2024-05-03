using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Movement : MonoBehaviour
{
    //Stats
    public float walkVelocity;
    public float runVelocity;
    public float jumpForce;
    public bool canMove;

    [HideInInspector]
    public float direction;
    [HideInInspector]
    public Rigidbody rigidBody;
    private Scr_Player_Animations scriptAnimation;

    private CapsuleCollider capsuleCollider;
    public LayerMask layerMask;

    public Vector3 halfExtents;

    public bool IsGrounded()
    {
        Vector3 center = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + 0.14f, capsuleCollider.bounds.center.z);
        Vector3 halfExtents = new Vector3(0.3f, 0.15f,0f);
        return Physics.CheckBox(center, halfExtents, capsuleCollider.transform.rotation, layerMask);
    }

    private Scr_Player_Life playerHealth;
    public bool isDamage;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerHealth = GetComponent<Scr_Player_Life>();
        scriptAnimation = GetComponentInChildren<Scr_Player_Animations>();
        canMove = true;
    }

    private void Update()
    {
        if (IsGrounded() && canMove)
        {
            //Horizontal Movement
            direction = Input.GetAxisRaw("Horizontal");

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDamage)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        else
        {
            if (IsGrounded())
            {
                if (canMove)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        rigidBody.velocity = new Vector3(runVelocity * direction, rigidBody.velocity.y, rigidBody.velocity.z);
                    }
                    else
                    {
                        rigidBody.velocity = new Vector3(walkVelocity * direction, rigidBody.velocity.y, rigidBody.velocity.z);
                    }
                }

                if (!canMove)
                {
                    rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
                }
            }
        }
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
        scriptAnimation.animator.Play("Anim_Player_Jump");
    }

    private void Animation(string anim)
    {
        scriptAnimation.animator.Play(anim);
    }

    public void Damage(float damage, float knockbackX, float knockbackY, Vector3 knockbackDirection)
    {
        // Aplicar el knockback en la dirección opuesta al golpe
        rigidBody.velocity = new Vector3(knockbackDirection.x * knockbackX, knockbackY, rigidBody.velocity.z);

        playerHealth.actualLife -= damage;
        isDamage = true;
    }
}
