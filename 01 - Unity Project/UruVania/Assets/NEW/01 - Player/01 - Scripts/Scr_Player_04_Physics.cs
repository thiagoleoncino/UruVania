using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Scr_Player_04_Physics : MonoBehaviour
{
    // Components
    private Rigidbody rigidBody;

    // Scripts
    private Scr_Player_03_Statistics playerStatistics;

    // Path Variables
    [Header("Path Following")]
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Loop;
    private float currentPathDistance;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerStatistics = GetComponent<Scr_Player_03_Statistics>();
    }

    // Horizontal movement guided by path (using forward motion)
    public void PlayerHorizontalMoveFunction(float speed)
    {
        if (pathCreator == null || Mathf.Abs(speed) < 0.01f)
        {
            PlayerStopMovementFunction();
            return;
        }

        // 1. Obtener distancia actual sobre el path
        currentPathDistance = pathCreator.path.GetClosestDistanceAlongPath(transform.position);

        // 2. Calcular nueva distancia sobre el path
        float targetDistance = currentPathDistance + speed * Time.deltaTime;

        // 3. Obtener la posición del punto actual sobre el path
        Vector3 pathPosNow = pathCreator.path.GetPointAtDistance(currentPathDistance, endOfPathInstruction);

        // 4. Calcular la dirección de avance sobre el path
        Vector3 direction = pathCreator.path.GetDirectionAtDistance(targetDistance, endOfPathInstruction);

        // 5. Aplicar movimiento en la dirección "forward" (hacia adelante) del path
        Vector3 targetPosition = pathPosNow + direction * speed * Time.deltaTime;

        // Mantener la misma altura (Y) que el objeto tenía originalmente
        targetPosition.y = transform.position.y;

        // Actualizar la posición del transform (sin usar Rigidbody)
        transform.position = targetPosition;
    }

    // Jump
    public void PlayerVerticalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, speed, rigidBody.velocity.z);
    }

    // Stop
    public void PlayerStopMovementFunction()
    {
        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
    }
}
