using System.Collections.Generic;
using UnityEngine;

public class Scr_PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;              // Puntos del camino
    public float moveSpeed = 2f;                // Velocidad de movimiento
    public float pointReachThreshold = 0.1f;    // Qué tan cerca debe estar para considerar que llegó

    private int currentPointIndex = 0;
    private Scr_Player_04_Physics physicsScript;

    void Start()
    {
        physicsScript = GetComponent<Scr_Player_04_Physics>();
    }

    void Update()
    {
        if (pathPoints.Length == 0 || physicsScript == null) return;

        Vector3 target = pathPoints[currentPointIndex].position;
        Vector3 direction = (target - transform.position).normalized;

        // Solo mueve en X y Z
        direction.y = 0;

        // Mueve horizontalmente
        physicsScript.PlayerHorizontalMoveFunction(direction.x * moveSpeed);

        // Avanza al siguiente punto si está cerca
        if (Vector3.Distance(transform.position, target) < pointReachThreshold)
        {
            currentPointIndex++;
            if (currentPointIndex >= pathPoints.Length)
            {
                currentPointIndex = 0; // O puedes hacer que se detenga
                physicsScript.PlayerStopMovementFunction();
                enabled = false; // Detener script si ya llegó
            }
        }
    }
}
