using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_B1_GurisCorre : MonoBehaviour
{
    public string runAnimation;
    public float runVelocityX;

    private Scr_Enemy_01_BasicFunctions enemyBasicFunctions;
    private Scr_Enemy_02_Animation enemyAnimation;

    void Start()
    {
        enemyBasicFunctions = GetComponentInParent<Scr_Enemy_01_BasicFunctions>();
        enemyAnimation = transform.parent.GetComponentInChildren<Scr_Enemy_02_Animation>();
    }

    //Horizontal Move Function
    public void EnemyRunFunction()
    {
        enemyBasicFunctions.enemyVelocityX = runVelocityX;
        enemyAnimation.ChangeAnimationFunction(runAnimation);
    }
}
