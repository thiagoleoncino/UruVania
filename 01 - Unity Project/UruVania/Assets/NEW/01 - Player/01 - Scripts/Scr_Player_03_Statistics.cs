using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_03_Statistics : MonoBehaviour
{
    [Header("Movement Stats")]
    public float playerWalkSpeed; //Horizontal walk speed velocity
    public float playerRunSpeed; //Horizontal run speed velocity
    [Space]
    public int playerJumpAmount; //The amount of jumps we can perform
    public int playerActualJumpAmount; //The actual amount of jumps left in game
    public float playerJumpForce; //Vertical jump force
    [Space]
    public float playerDashSpeed; //The distance traveled in the dash
    public float playerDodgeSpeed; //The distance traveled in the dodge

    [Header("Meter Stats")]
    public float playerTotalLife = 100; //Total amount of life
    public float playerActualLife; //The actual amount of life in game
    [Space]
    public float playerTotalMagic = 100; //Total amount of magic
    public float playerActualMagic; //The actual amount of magic in game

    // Start is called before the first frame update
    private void Start()
    {
        playerActualJumpAmount = playerJumpAmount;
        playerActualLife = playerTotalLife;
        playerActualMagic = playerTotalMagic;
    }

}