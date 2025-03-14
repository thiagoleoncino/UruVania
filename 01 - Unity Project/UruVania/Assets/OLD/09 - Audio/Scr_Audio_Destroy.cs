using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Audio_Destroy : MonoBehaviour
{
    public GameObject audioPostDestroy;
    public AudioClip destroyEffect;

    public void DestroyEffect()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject newPrefab = Instantiate(audioPostDestroy, spawnPosition, spawnRotation);

        AudioSource newAudioSource = newPrefab.GetComponent<AudioSource>();
        if (newAudioSource != null && destroyEffect != null)
        {
            newAudioSource.clip = destroyEffect;
            newAudioSource.Play();
        }
    }
}
