using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scr_Player_04_Physics : MonoBehaviour
{
    //Components Variables
    private Rigidbody rigidBody;

    //Scripts Variables
    private Scr_Player_03_Statistics playerStatistics;

    //Awake is the first thing to update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
    }

    //Horizontal movement function
    public void PlayerHorizontalMoveFunction(float speed)
    {
        Vector3 direction = transform.right * speed;
        rigidBody.velocity = new Vector3(direction.x, rigidBody.velocity.y, direction.z);
    }

    //Jump movement function
    public void PlayerVerticalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, speed, rigidBody.velocity.z);
    }

    //Stop movement function
    public void PlayerStopMovementFunction()
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
    }
}
