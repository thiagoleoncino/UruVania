using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scr_Player_01_Controls;

public class Scr_Player_02_States : MonoBehaviour
{
    public enum GroundState
    {
        Grounded,
        Airborn
    }

    public enum ActionType
    {
        Passive,
        Cancelable,
        SemiCancelable,
        NonCancelable
    }

    public GroundState currentGroundState;
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

    public ActionType currentState;

    public bool passiveAction
    {
        get => currentState == ActionType.Passive;
        set { if (value) currentState = ActionType.Passive; }
    }
    public bool cancelableAction
    {
        get => currentState == ActionType.Cancelable;
        set { if (value) currentState = ActionType.Cancelable; }
    }
    public bool semiCancelableAction
    {
        get => currentState == ActionType.SemiCancelable;
        set { if (value) currentState = ActionType.SemiCancelable; }
    }
    public bool noCancelableAction
    {
        get => currentState == ActionType.NonCancelable;
        set { if (value) currentState = ActionType.NonCancelable; }
    }

    private CapsuleCollider capsuleCollider;
    [Space]
    public LayerMask groundLayerMask;
    private Vector3 halfExtents;
    public bool playerLand;

    private bool wasAirborn = false;

    public bool IsGrounded() //Grounded Bool Function
    {
        Vector3 center = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y + 0.14f, capsuleCollider.bounds.center.z);
        Vector3 halfExtents = new Vector3(0.3f, 0.15f, 0f);
        return Physics.CheckBox(center, halfExtents, capsuleCollider.transform.rotation, groundLayerMask);
    }

    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        stateGrounded = IsGrounded(); // Grounded
        stateAirborn = !IsGrounded(); // Airborn

        // Verificar si el estado cambia de Airborn a Grounded
        if (stateGrounded && wasAirborn)
        {
            wasAirborn = false;
            StartCoroutine(HandlePlayerLand());
        }

        if (stateAirborn)
        {
            wasAirborn = true;
        }
    }

    private IEnumerator HandlePlayerLand()
    {
        playerLand = true;  // Activar playerLand
        yield return new WaitForSeconds(0.1f);  // Mantenerlo activo durante 2 segundos (puedes cambiar este tiempo)
        playerLand = false; // Desactivar playerLand despu�s de 2 segundos
    }
}
