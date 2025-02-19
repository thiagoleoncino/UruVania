using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Objeto_Bridge : MonoBehaviour
{
    public bool act;
    public Transform tr;
    public Vector3 targetRotation;
    public float rotationSpeed = 30f; // Velocidad de rotación

    // Update is called once per frame
    void Update()
    {
        if (act)
        {
            // Obtener la rotación actual del objeto
            Quaternion currentRotation = tr.rotation;

            // Calcular la rotación hacia los ángulos deseados
            Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

            // Rotar gradualmente hacia los ángulos deseados
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
