using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class Scr_Player_12_Camara : MonoBehaviour
{
    public float deadZoneInGround;
    public float deadZoneInAir;
    public float transitionSpeed = 2f;

    private Scr_Player_02_State playerState;
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer transposer;

    private void Start()
    {
        playerState = GetComponentInParent<Scr_Player_02_State>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        if (transposer == null) return;

        if (playerState.stateGrounded)
        {
            transposer.m_DeadZoneHeight = Mathf.Lerp(
                transposer.m_DeadZoneHeight,
                deadZoneInGround,
                Time.deltaTime * transitionSpeed
            );
        }
        else if (playerState.stateAirborn)
        {
            transposer.m_DeadZoneHeight = deadZoneInAir;
        }
    }
}