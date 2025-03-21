using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scr_Player_04_Physics : MonoBehaviour
{
    //Components
    private Rigidbody rigidBody;

    //Scripts
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
        rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, rigidBody.velocity.z);
    }

    //Jump movement function
    public void PlayerVerticalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, speed, rigidBody.velocity.z);
    } 

    public void PlayerStopMovementFunction()
    {
        rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
    }
}
