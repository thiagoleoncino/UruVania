using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_03_Movement : MonoBehaviour
{
    // Movement Bools
    public bool playerCanMove; 
    public bool playerIsGrounded;
    public bool IsGrounded() //Grounded Bool Function
    {
        Vector3 center = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + 0.14f, capsuleCollider.bounds.center.z);
        Vector3 halfExtents = new Vector3(0.3f, 0.15f, 0f);
        return Physics.CheckBox(center, halfExtents, capsuleCollider.transform.rotation, groundLayerMask);
    }

    // Movement Stats
    [Space]
    private Scr_Player_02_Stats playerStats;
    public float moveDirection;

    //Movement Components
    [HideInInspector]
    private Scr_Player_01_Controls playerControls;
    public Rigidbody rigidBody;
    private CapsuleCollider capsuleCollider;
    [Space]
    public LayerMask groundLayerMask; //The Layers that are considered Surface
    private Vector3 halfExtents; //Determines the distance for the ground check

    void Start()
    {
        playerControls = GetComponent<Scr_Player_01_Controls>();
        playerStats = GetComponent<Scr_Player_02_Stats>();
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerCanMove = true;
    }

    private void Update()
    {
        playerIsGrounded = IsGrounded();

        if (playerIsGrounded)
        {
            if (playerCanMove)
            {
                //Direction
                if (playerControls.directionRight)
                {
                    moveDirection = 1;
                }
                else if (playerControls.directionLeft)
                {
                    moveDirection = -1;
                }
                else { moveDirection = 0; }
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerIsGrounded)
        {
            if (playerCanMove)
            {
                //Horizontal Movement
                if (playerControls.leftTrigger)
                {
                    //Character Run
                    HorizontalMovement(playerStats.playerRunSpeed * moveDirection);
                }
                else 
                {
                    //Caracter Walk
                    HorizontalMovement(playerStats.playerWalkSpeed * moveDirection);
                }

                //Jump
                if (playerControls.button3)
                {
                    VerticalMovement(playerStats.playerJumpForce);
                }
            }

            if (!playerCanMove)
            {
                //Stop player movment
                HorizontalMovement(0);
                VerticalMovement(0);
            }
        }
    }

    private void HorizontalMovement(float velX) //The function modifies the speed of the X axis
    {
        rigidBody.velocity = new Vector3(velX, rigidBody.velocity.y, rigidBody.velocity.z);
    }

    private void VerticalMovement(float velY) //The function modifies the speed of the Y axis
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, velY, rigidBody.velocity.z);
    }

}
