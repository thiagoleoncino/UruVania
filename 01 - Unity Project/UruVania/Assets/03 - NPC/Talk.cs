using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    private SpriteRenderer childSpriteRenderer;
    private void Start()
    {
        // Asegura que el hijo tenga un SpriteRenderer
        childSpriteRenderer = GetComponent<SpriteRenderer>();

        if (childSpriteRenderer != null)
        {
            childSpriteRenderer.enabled = false; // Apagar al inicio
        }
        else
        {
            Debug.LogWarning("No se encontró un SpriteRenderer en el hijo.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && childSpriteRenderer != null)
        {
            childSpriteRenderer.enabled = true; // Prender sprite del hijo
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && childSpriteRenderer != null)
        {
            childSpriteRenderer.enabled = false; // Apagar sprite del hijo
        }
    }
}