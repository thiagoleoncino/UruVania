using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_Player_01_Control;

public class Scr_Player_02_State : MonoBehaviour
{
    //List of Ground States
    public enum GroundState
    {
        Grounded,
        Airborn
    }

    //List of Normal Action Types
    public enum NormalStatesType
    {
        Passive,
        Cancelable,
        SemiCancelable,
        NonCancelable
    }

    //List of Combat Action Types
    public enum CombatStatesType
    {
        Normal,
        Invulnerable,
        Damage
    }

    //Enum list references
    public NormalStatesType currentActionState;
    public CombatStatesType currentCombatState;
    [Space]
    public GroundState currentGroundState;

    //Ground states bool
    public bool stateGrounded
    {
        get => currentGroundState == GroundState.Grounded;
        set { if (value) currentGroundState = GroundState.Grounded; }
    }
    public bool stateAirborn
    {
        get => currentGroundState == GroundState.Airborn;
        set { if (value) currentGroundState = GroundState.Airborn; }
    }

    //Normal states bools
    public bool passiveAction
    {
        get => currentActionState == NormalStatesType.Passive;
        set { if (value) currentActionState = NormalStatesType.Passive; }
    }
    public bool cancelableAction
    {
        get => currentActionState == NormalStatesType.Cancelable;
        set { if (value) currentActionState = NormalStatesType.Cancelable; }
    }
    public bool semiCancelableAction
    {
        get => currentActionState == NormalStatesType.SemiCancelable;
        set { if (value) currentActionState = NormalStatesType.SemiCancelable; }
    }
    public bool noCancelableAction
    {
        get => currentActionState == NormalStatesType.NonCancelable;
        set { if (value) currentActionState = NormalStatesType.NonCancelable; }
    }

    //Combat states bools
    public bool normalCombatAction
    {
        get => currentCombatState == CombatStatesType.Normal;
        set { if (value) currentCombatState = CombatStatesType.Normal; }
    }
    public bool invulnerableCombatAction
    {
        get => currentCombatState == CombatStatesType.Invulnerable;
        set { if (value) currentCombatState = CombatStatesType.Invulnerable; }
    }
    public bool damageCombatAction
    {
        get => currentCombatState == CombatStatesType.Damage;
        set { if (value) currentCombatState = CombatStatesType.Damage; }
    }

    //Ground detection variables
    private CapsuleCollider capsuleCollider;
    private Vector3 halfExtents;
    public LayerMask groundLayerMask;

    //Land bools
    public bool playerLand;
    private bool playerIsGrounded;
    private bool playerWasAirborn = false;

    private bool newCollisionState;

    // Start is called before the first frame update
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Update ground state bools
        playerIsGrounded = IsGroundedFunction();
        currentGroundState = playerIsGrounded ? GroundState.Grounded : GroundState.Airborn;

        //Handle landing
        if (stateAirborn)
        {
            playerWasAirborn = true;
        }
        if (stateGrounded && playerWasAirborn)
        {
            playerWasAirborn = false;
            StartCoroutine(PlayerLandCoroutine());
        }

        //Handle enemy collision
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Layer_Player"), LayerMask.NameToLayer("Layer_Enemy"), invulnerableCombatAction);
    }

    //Grounded bool function
    public bool IsGroundedFunction()
    {
        Vector3 center = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + 0.14f, capsuleCollider.bounds.center.z);
        Vector3 halfExtents = new Vector3(0.3f, 0.15f, 0f);
        return Physics.CheckBox(center, halfExtents, capsuleCollider.transform.rotation, groundLayerMask);
    }

    //Player land function
    private IEnumerator PlayerLandCoroutine()
    {
        playerLand = true;
        yield return new WaitForSeconds(0.1f);
        playerLand = false;
    }

}