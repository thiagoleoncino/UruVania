using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scr_Player_04_Physics : MonoBehaviour
{
    //Components
    private Rigidbody rigidBody;

    //Scripts
    private Scr_Player_03_Statistics characterStat;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        characterStat = GetComponent<Scr_Player_03_Statistics>();
    }

    public void PlayerHorizontalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, rigidBody.velocity.z);
    } //Horizontal movement function

    public void PlayerVerticalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, speed, rigidBody.velocity.z);
    } //Jump movement function

}
