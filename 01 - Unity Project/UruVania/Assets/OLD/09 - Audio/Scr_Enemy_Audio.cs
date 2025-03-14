using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Audio : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject audioPostDestroy;

    public AudioClip deathEffect;
    public AudioClip[] audioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void AudioEffect1()
    {
        PlayAudioClip(0);
    }

    private void AudioEffect2()
    {
        PlayAudioClip(1);
    }

    private void AudioEffect3()
    {
        PlayAudioClip(2);
    }

    private void AudioEffect4()
    {
        PlayAudioClip(3);
    }

    private void AudioEffect5()
    {
        PlayAudioClip(4);
    }

    private void AudioEffect6()
    {
        PlayAudioClip(5);
    }

    private void AudioEffect7()
    {
        PlayAudioClip(6);
    }

    private void AudioEffect8()
    {
        PlayAudioClip(7);
    }

    private void AudioEffect9()
    {
        PlayAudioClip(8);
    }

    private void AudioEffect10()
    {
        PlayAudioClip(9);
    }


    public void DeathEffect()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = transform.rotation;

        GameObject newPrefab = Instantiate(audioPostDestroy, spawnPosition, spawnRotation);

        AudioSource newAudioSource = newPrefab.GetComponent<AudioSource>();
        if (newAudioSource != null && deathEffect != null)
        {
            newAudioSource.clip = deathEffect;
            newAudioSource.Play();
        }
    }

    private void PlayAudioClip(int index)
    {
        if (audioClips != null && index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }

}
