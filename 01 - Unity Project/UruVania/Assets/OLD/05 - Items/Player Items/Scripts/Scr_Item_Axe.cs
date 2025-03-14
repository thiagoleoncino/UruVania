using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_Item_Axe : MonoBehaviour
{
    private Rigidbody rigidBody;
    private CapsuleCollider capsule;
    private Scr_Player_Animations playerDirection;

    public float distanceX;
    public float distanceY;
    public float velocidadRotacion;
    public float necessaryMagic;

    private float tiempoRegresivo = 2.5f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        velocidadRotacion = velocidadRotacion * -1000;

        playerDirection = GameObject.FindWithTag("Player").GetComponentInChildren<Scr_Player_Animations>();

        SetInitialVelocity();
    }

    void Update()
    {
        RotateObject();
        UpdateDestructionTimer();
    }

    void SetInitialVelocity()
    {
        Vector3 initialVelocity = new Vector3(distanceX, distanceY, 0f);

        if (!playerDirection.facingRight)
        {
            initialVelocity.x = -initialVelocity.x;
        }

        rigidBody.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }

    void UpdateDestructionTimer()
    {
        tiempoRegresivo -= Time.deltaTime;

        if (tiempoRegresivo <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
