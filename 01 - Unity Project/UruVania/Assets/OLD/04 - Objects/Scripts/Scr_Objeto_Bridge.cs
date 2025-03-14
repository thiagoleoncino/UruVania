using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Objeto_Bridge : MonoBehaviour
{
    public bool act;
    public Transform tr;
    public Vector3 targetRotation;
    public float rotationSpeed = 30f; // Velocidad de rotaci�n

    // Update is called once per frame
    void Update()
    {
        if (act)
        {
            // Obtener la rotaci�n actual del objeto
            Quaternion currentRotation = tr.rotation;

            // Calcular la rotaci�n hacia los �ngulos deseados
            Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

            // Rotar gradualmente hacia los �ngulos deseados
            tr.rotation = Quaternion.RotateTowards(currentRotation, targetQuaternion, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            act = true;
        }
    }
}
