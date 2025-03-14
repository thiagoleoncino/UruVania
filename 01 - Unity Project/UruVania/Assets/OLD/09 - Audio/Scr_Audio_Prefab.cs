using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Audio_Prefab : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource.clip != null)
        {
            StartCoroutine(DestroyAfterAudioClip());
        }
        else
        {
            Debug.LogWarning("No se ha asignado un AudioClip al AudioSource.");
        }
    }

    private IEnumerator DestroyAfterAudioClip()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}
