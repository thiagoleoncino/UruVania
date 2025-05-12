using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Direction2 : MonoBehaviour
{
    public float Direction1;
    public float Direction2A;

    public bool useExitPositions = false;
    public Vector3 exitPosition1;
    public Vector3 exitPosition2A;

    private Transform player;
    private bool playerInside = false;
    private Quaternion lastValidRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        player = other.transform;
        playerInside = true;
    }

    private void Update()
    {
        if (!playerInside || player == null) return;

        float localZ = transform.InverseTransformPoint(player.position).z;
        float triggerSizeZ = ((BoxCollider)GetComponent<Collider>()).size.z * transform.localScale.z;
        float normalizedZ = Mathf.InverseLerp(-triggerSizeZ / 2f, triggerSizeZ / 2f, localZ);

        float newDirection = Mathf.Lerp(Direction1, Direction2A, normalizedZ);
        Quaternion targetRotation = Quaternion.Euler(0f, newDirection, 0f);

        player.rotation = targetRotation;
        lastValidRotation = targetRotation;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (other.transform != player) return;

        float localZ = transform.InverseTransformPoint(player.position).z;

        if (useExitPositions)
        {
            Vector3 newPos;

            if (localZ < 0)
            {
                newPos = exitPosition1;
                newPos.y = player.position.y;
                player.position = newPos;
                player.rotation = Quaternion.Euler(0f, Direction1, 0f);
            }
            else
            {
                newPos = exitPosition2A;
                newPos.y = player.position.y;
                player.position = newPos;
                player.rotation = Quaternion.Euler(0f, Direction2A, 0f);
            }
        }

        Debug.Log("Player exited at: " + player.position);

        player = null;
        playerInside = false;
    }

    private void OnDrawGizmos()
    {
        BoxCollider box = GetComponent<BoxCollider>();
        if (box == null) return;

        Vector3 center = transform.TransformPoint(box.center);
        Matrix4x4 worldToLocal = transform.worldToLocalMatrix;
        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        List<Vector3> entryExitPoints = new List<Vector3>();

        Vector3? GetEdgePoint(float angle)
        {
            Vector3 worldDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            Vector3 localOrigin = worldToLocal.MultiplyPoint3x4(center);
            Vector3 localDir = worldToLocal.MultiplyVector(worldDir).normalized;
            Vector3 extents = box.size * 0.5f;

            float tMin = float.NegativeInfinity;
            float tMax = float.PositiveInfinity;

            for (int i = 0; i < 3; i++)
            {
                float origin = localOrigin[i];
                float direction = localDir[i];
                float min = -extents[i];
                float max = extents[i];

                if (Mathf.Abs(direction) < 1e-5f)
                {
                    if (origin < min || origin > max)
                        return null;
                }
                else
                {
                    float t1 = (min - origin) / direction;
                    float t2 = (max - origin) / direction;

                    if (t1 > t2) (t1, t2) = (t2, t1);

                    tMin = Mathf.Max(tMin, t1);
                    tMax = Mathf.Min(tMax, t2);

                    if (tMin > tMax) return null;
                }
            }

            Vector3 localHit = localOrigin + localDir * tMax;
            return localToWorld.MultiplyPoint3x4(localHit);
        }

        // Obtener puntos de entrada/salida
        Vector3? point1 = GetEdgePoint(Direction1 + 180f - 90f);
        Vector3? point2 = GetEdgePoint(Direction2A - 90f);

        // Si tenemos ambos puntos, simulamos el recorrido
        if (point1.HasValue && point2.HasValue)
        {
            Vector3 start = point1.Value;
            Vector3 end = point2.Value;

            Gizmos.color = Color.cyan;

            int steps = 30;
            Vector3[] localCurve = new Vector3[steps + 1];
            localCurve[0] = Vector3.zero;

            // Paso 1: construir la curva con forma original desde (0,0,0)
            Vector3 currentPosition = Vector3.zero;

            for (int i = 1; i <= steps; i++)
            {
                float t = i / (float)steps;

                float localZ = Mathf.Lerp(-box.size.z * 0.5f, box.size.z * 0.5f, t);
                float normalizedZ = Mathf.InverseLerp(-box.size.z * 0.5f, box.size.z * 0.5f, localZ);
                float currentAngle = Mathf.Lerp(Direction1, Direction2A, normalizedZ);

                float rotationAngle = -90f;
                currentAngle += rotationAngle;

                Vector3 forwardDir = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward;
                float stepLength = 1f;
                Vector3 offset = forwardDir.normalized * stepLength;

                currentPosition += offset;
                localCurve[i] = currentPosition;
            }

            // Paso 2: transformar la curva para que empiece en start y termine en end
            Vector3 localStart = localCurve[0];
            Vector3 localEnd = localCurve[steps];
            Vector3 localDirection = localEnd - localStart;
            float localLength = localDirection.magnitude;

            Vector3 targetDirection = end - start;
            float targetLength = targetDirection.magnitude;

            Quaternion rotation = Quaternion.FromToRotation(localDirection, targetDirection);
            float scale = targetLength / localLength;

            // Paso 3: aplicar la transformación y dibujar
            Vector3 previous = start;
            Vector3 midPoint = Vector3.zero;

            for (int i = 1; i <= steps; i++)
            {
                Vector3 transformed = rotation * (localCurve[i] - localStart) * scale + start;
                Gizmos.DrawLine(previous, transformed);
                previous = transformed;

                if (i == steps / 2)
                {
                    midPoint = transformed;
                }
            }

            // Dibuja la esfera amarilla, pero sin las etiquetas
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(midPoint, 0.05f); // Esfera más pequeña

            // Dibuja las etiquetas solo en los puntos extremos
            Handles.Label(point1.Value + Vector3.up * 0.2f, $"({point1.Value.x:F2}, {point1.Value.y:F2}, {point1.Value.z:F2})");
            Handles.Label(point2.Value + Vector3.up * 0.2f, $"({point2.Value.x:F2}, {point2.Value.y:F2}, {point2.Value.z:F2})");
        }

        // Dibuja los puntos amarillos
        if (point1.HasValue)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point1.Value, 0.05f); // Esfera más pequeña
            Handles.Label(point1.Value + Vector3.up * 0.2f, $"({point1.Value.x:F2}, {point1.Value.y:F2}, {point1.Value.z:F2})");
        }

        if (point2.HasValue)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point2.Value, 0.05f); // Esfera más pequeña
            Handles.Label(point2.Value + Vector3.up * 0.2f, $"({point2.Value.x:F2}, {point2.Value.y:F2}, {point2.Value.z:F2})");
        }
    }
}