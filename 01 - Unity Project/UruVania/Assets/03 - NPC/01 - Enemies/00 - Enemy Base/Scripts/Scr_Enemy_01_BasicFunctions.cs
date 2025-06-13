using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_Enemy_01_BasicFunctions;
using static Scr_Player_02_State;

public class Scr_Enemy_01_BasicFunctions : MonoBehaviour
{
    //Enemy State Enum
    public enum EnemyState
    {
        Passive,
        Damaged,
        NoCancelable
    }
    public bool passiveState
    {
        get => currentEnemyState == EnemyState.Passive;
        set { if (value) currentEnemyState = EnemyState.Passive; }
    }
    public bool damagedState
    {
        get => currentEnemyState == EnemyState.Damaged;
        set { if (value) currentEnemyState = EnemyState.Damaged; }
    }
    public bool noCancelableState
    {
        get => currentEnemyState == EnemyState.NoCancelable;
        set { if (value) currentEnemyState = EnemyState.NoCancelable; }
    }

    //Enemy Actions Enum
    public enum EnemyActions
    {
        Idle,
        Movement,
        Dead
    }
    public bool idleAction
    {
        get => currentEnemyAction == EnemyActions.Idle;
        set { if (value) currentEnemyAction = EnemyActions.Idle; }
    }
    public bool movementAction
    {
        get => currentEnemyAction == EnemyActions.Movement;
        set { if (value) currentEnemyAction = EnemyActions.Movement; }
    }
    public bool deadAction
    {
        get => currentEnemyAction == EnemyActions.Dead;
        set { if (value) currentEnemyAction = EnemyActions.Dead; }
    }

    //Components
    private Scr_Enemy_02_Animation enemyAnimation;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigidBody;

    //Public Variables
    [Header("Enemy Basic States")]
    public EnemyState currentEnemyState;
    public EnemyActions currentEnemyAction;
    [Space]
    [Header ("Enemy Basic Animations")] 
    public string enemyIdleAnimation;
    public string enemyMoveXAnimation;
    public string enemyHitAnimation;
    public string enemyDeathAnimation;
    [Space]
    [Header("Enemy Basic Statics")]
    [Space]
    public float enemyLifeAmount;
    public float enemyActualLifeAmount;
    [Space]
    public bool hasShield;
    public float shieldAmount;
    public float actualShieldAmount;
    [Space]
    public float enemyVelocityX;
    public float enemyVelocityY;
    [Space]
    public bool hitDetected;
    public int hitCount;
    [Space]
    public float enemyKnockbackX;
    public float enemyKnockbackY;
    [Space]
    public float passiveDamage;
    public float passiveKnocbackX;
    public float passiveKnocbackY;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        enemyAnimation = GetComponentInChildren<Scr_Enemy_02_Animation>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        enemyActualLifeAmount = enemyLifeAmount;
        actualShieldAmount = shieldAmount;
    }
  
    //Update is called once per frame
    private void Update()
    {
        //If enemy life is more than 0
        if (enemyActualLifeAmount > 0)
        {
            if (passiveState)
            {
                if (idleAction) EnemyIdelFunction();
                if (movementAction) EnemyHorizontalMoveFunction();
            }
        }

        //If enemy life is less than or equal 0 (Death)
        if (enemyActualLifeAmount <= 0)
        {
            EnemyDeathFunction();
        }

        //If shield is less than or equal 0
        if (actualShieldAmount <= 0)
        { 
            hasShield = false;
        }

        if (enemyAnimation.AnimationEventFunction(enemyHitAnimation, 0.95f))
        {
            damagedState = false;
            hitDetected = false;
            passiveState = true;
        }

    }

    //Idle Action Function
    public void EnemyIdelFunction()
    {
        enemyAnimation.ChangeAnimationFunction(enemyIdleAnimation);
        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
    }
    
    //Horizontal Move Function
    public void EnemyHorizontalMoveFunction()
    {
        float direction = transform.eulerAngles.y == 180 ? 1 : -1;
        rigidBody.velocity = new Vector3(enemyVelocityX * direction, rigidBody.velocity.y, rigidBody.velocity.z);
        enemyAnimation.ChangeAnimationFunction(enemyMoveXAnimation);
    }

    //Enemy Damaged Function
    public void EnemyHitFunction(Collider other)
    {
        damagedState = true;
        hitDetected = true;

        hitCount++;
        enemyActualLifeAmount--;
        
        if(hasShield)
        {
            actualShieldAmount--;
        }
        else
        {
            EnemyKnockbackFunction(other);
            enemyAnimation.ChangeAnimationFunction(enemyHitAnimation);
            if (enemyAnimation.actualAnimation == enemyHitAnimation)
            {
                enemyAnimation.ResetAnimationFunction(enemyHitAnimation);
            }
        }
    }

    //Enemy Knocback Function
    public void EnemyKnockbackFunction(Collider other)
    {
        //Determines Knocback Direction
        Transform attackerTransform = other.transform.root;

        Vector3 attackDirection = transform.position - attackerTransform.position;
        attackDirection.Normalize();

        float direction = attackDirection.x >= 0 ? 1 : -1;

        //Knocback Aplication
        rigidBody.velocity = new Vector3(enemyKnockbackX * direction, enemyKnockbackY, rigidBody.velocity.z);

        //Knocback Direction
        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    //Death Action Function
    public void EnemyDeathFunction()
    {
        enemyAnimation.ChangeAnimationFunction(enemyDeathAnimation);

        capsuleCollider.enabled = false;
        deadAction = true;

        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);

        if (enemyAnimation.AnimationEventFunction(enemyDeathAnimation, 0.95f))
        {
            Destroy(gameObject);
        }
    }

    //Walls and corner detection
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Layer_Ground"))
        {
            float newRotationY = transform.eulerAngles.y == 0 ? 180 : 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, newRotationY, transform.eulerAngles.z);
        }
    }

    //Detection Functions
    public void ActivateIdleAction()
    {
        idleAction = true;
    }
    public void ActivateHorizontalMoveAction()
    {
        movementAction = true;
    }
}