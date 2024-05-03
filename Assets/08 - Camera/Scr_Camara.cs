using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Camara : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform targetObject;
    public Scr_Player_Movement player;
    public CinemachineFramingTransposer transposer;

    [System.Serializable]
    public struct Range
    {
        public float minValue;
        public float maxValue;
    }

    public Range[] cameraRanges;

    public float DampingMax;
    public float DampingMin;
    public float maxHeight = 0.5f;
    private float originalYPosition;

    private void Start()
    {
        originalYPosition = targetObject.position.y;
        transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        bool isInAnyRange = false;

        foreach (Range range in cameraRanges)
        {
            if (targetObject.position.x > range.minValue && targetObject.position.x < range.maxValue)
            {
                isInAnyRange = true;

                if (player.IsGrounded())
                {
                    originalYPosition = targetObject.position.y;
                    transposer.m_YDamping = DampingMax;
                }
                else
                {
                    transposer.m_YDamping = DampingMin;
                }

                // Calcular la diferencia entre la posición actual y la posición original del objeto
                float deltaY = targetObject.position.y - originalYPosition;
                float clampedDeltaY = Mathf.Clamp(deltaY, 0.1f, maxHeight); // Limitar la diferencia
                float normalizedDeltaY = clampedDeltaY / maxHeight; // Normalizar la diferencia limitada

                transposer.m_DeadZoneHeight = normalizedDeltaY;

                break; // Salir del bucle si se encuentra en algún rango
            }
        }

        if (!isInAnyRange)
        {
            transposer.m_DeadZoneHeight = 2;
        }

    }
}
