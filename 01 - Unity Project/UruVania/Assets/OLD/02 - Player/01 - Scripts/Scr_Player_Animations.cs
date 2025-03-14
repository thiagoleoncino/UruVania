using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Scr_Player_Animations : MonoBehaviour
{
    private Scr_Player_Movement playerMove;
    private Scr_Player_Life playerLife;
    private Scr_Player_Magic playerMagic;
    public BoxCollider box;
    private CapsuleCollider capsule;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public bool restart;

    public bool facingRight = true;

    void Start()
    {
        playerMove = GetComponentInParent<Scr_Player_Movement>();
        playerMagic = GetComponentInParent<Scr_Player_Magic>();
        playerLife = GetComponentInParent<Scr_Player_Life>();
        animator = GetComponent<Animator>();
        capsule = GetComponentInParent<CapsuleCollider>();
    }

    void Update()
    {
        if(playerMove.IsGrounded() && playerMove.playerCanMove)
        {
            //Horizontal Movement Animations
            animator.SetFloat("Parameter_Speed_X", Mathf.Abs(playerMove.moveDirection));

            //Flip
            if (playerMove.moveDirection < 0 && facingRight || playerMove.moveDirection > 0 && !facingRight) FlipCharacter();
        }

        if (!playerMove.IsGrounded())
        {
            animator.SetFloat("Parameter_Speed_Y", Mathf.Abs(playerMove.rigidBody.velocity.y));
        }

        animator.SetBool("Parameter_Grounded", playerMove.IsGrounded());

        if (Input.GetButtonDown("Fire1") && playerMove.playerCanMove)
        {
            animator.Play("Anim_Player_Attack");
            animator.SetBool("Parameter_Attacking", true);
            playerMove.playerCanMove = false;
        }

        if (Input.GetButtonDown("Fire2") && playerMove.playerCanMove && playerMagic.enoughMagic == true)
        {
            animator.Play("Anim_Player_Item");
            animator.SetBool("Parameter_Attacking", true);
            playerMove.playerCanMove = false;
        }

        if (playerMove.playerIsDamage)
        {
            if(playerLife.actualLife <= 0)
            {
                Death();
            }
            else
            {
                animator.Play("Anim_Player_Damage");
                animator.SetBool("Parameter_Damage", true);
            }
        }

        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("Parameter_Shift", isShiftPressed);

    }

    void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    } //Codigo para girar al personaje

    void AttackOver()
    {
        playerMove.playerCanMove = true;
    }

    void Idle()
    {
        playerMove.playerCanMove = true;
        playerMove.playerIsDamage = false;
        animator.SetBool("Parameter_Attacking", false);
        animator.SetBool("Parameter_Damage", false);
    }

    void Land()
    {
        playerMove.playerCanMove = false;
    }

    void LandEnd()
    {
        playerMove.playerCanMove = true;
        animator.Play("Anim_Player_Idle");
    }

    void Item()
    {
        playerMagic.UseItem();
    }

    void Death()
    {
        animator.Play("Anim_Player_Death");
        animator.SetBool("Parameter_Death", true);
        box.enabled = false;
    }

    void Restart()
    {
        restart = true;
    }

}
