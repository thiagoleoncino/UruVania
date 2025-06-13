using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Scr_Player_04_Physics : MonoBehaviour
{
    // Components
    private Rigidbody rigidBody;

    // Path Variables
    public PathCreator followingPath;
    public EndOfPathInstruction endOfPathBehavior;
    private float currentPathDistance;

    // Movimiento persistente
    private bool isMovingHorizontally = false;
    private float persistentHorizontalSpeed = 0f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update movement (for physics)
    void FixedUpdate()
    {
        //If not moving horizontally or if the path is not assigned
        if (!isMovingHorizontally || followingPath == null)
            return;

        //Get the closest distance along the path from the current position and Get the direction of the path at that point
        currentPathDistance = followingPath.path.GetClosestDistanceAlongPath(transform.position);
        Vector3 direction = followingPath.path.GetDirectionAtDistance(currentPathDistance, endOfPathBehavior).normalized;

        //Calculate the velocity along the path direction
        Vector3 horizontalVelocity = direction * persistentHorizontalSpeed;
        float verticalVelocity = rigidBody.velocity.y;
        rigidBody.velocity = new Vector3(horizontalVelocity.x, verticalVelocity, horizontalVelocity.z);

        //Correct position to stay centered on the path
        Vector3 pathPosition = followingPath.path.GetPointAtDistance(currentPathDistance, endOfPathBehavior);
        transform.position = new Vector3(pathPosition.x, transform.position.y, pathPosition.z);
    }

    // Movimiento horizontal guiado por el path (usando movimiento físico)
    public void PlayerHorizontalMoveFunction(float speed)
    {
        if (followingPath == null || Mathf.Abs(speed) < 0.01f)
        {
            isMovingHorizontally = false;
            return;
        }

        // Stores the velocity
        persistentHorizontalSpeed = speed;
        isMovingHorizontally = true;
    }

    // Movimiento vertical (salto)
    public void PlayerVerticalMoveFunction(float speed)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, speed, rigidBody.velocity.z);
    }

    // Detener movimiento (horizontal)
    public void PlayerStopMovementFunction()
    {
        isMovingHorizontally = false;
        persistentHorizontalSpeed = 0f;

        rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (CollidedHorizontally(collision))
        {
           PlayerStopMovementFunction();
        }
    }

    private bool CollidedHorizontally(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal.normalized;

            // Si el contacto viene de un lado (X o Z) y no de arriba o abajo
            if (Mathf.Abs(normal.y) < 0.5f)
            {
                return true;
            }
        }
        return false;
    }

}