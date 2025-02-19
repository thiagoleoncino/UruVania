using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Follow_Manager : MonoBehaviour
{
    public Transform followObject;
    public bool bossCamara;
    public Vector3 bossPosition;

    private void Start()
    {
        bossCamara = false;
    }

    private void Update()
    {
        if (bossCamara)
        {
            Vector3 targetPosition = bossPosition;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, 2f * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = followObject.transform.position;
        }
    }
}
