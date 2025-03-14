using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Audio : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    private Scr_Player_Life playerLife;

    public AudioClip stepsEffect;
    public AudioClip jumpEffect;
    public AudioClip landingEffect;
    public AudioClip attackEffect;

    public AudioClip itemEffectA;
    public AudioClip itemEffectB;
    public AudioClip damageEffect;
    public AudioClip deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = GetComponentInParent<Scr_Player_Life>();
        audioSource1.volume = 0.3f;
        audioSource2.volume = 0.3f;
    }

    private void AudioSteps()
    {
        audioSource1.clip = stepsEffect;
        audioSource1.Play();
    }

    private void AudioJump()
    {
        audioSource1.clip = jumpEffect;
        audioSource1.Play();
    }

    private void AudioLanding()
    {
        audioSource1.clip = landingEffect;
        audioSource1.Play();
    }

    private void AudioAttack()
    {
        audioSource1.clip = attackEffect;
        audioSource1.Play();
    }

    private void AudioItem()
    {
        float randomValue = Random.value;

        if (randomValue <= 0.7f)
        {
            audioSource2.clip = itemEffectA;
        }
        else
        {
            audioSource2.clip = itemEffectB;
        }

        audioSource2.Play();
    }

    private void AudioDamage()
    {
        audioSource2.clip = damageEffect;
        audioSource2.Play();
    }

    private void AudioDeath()
    {
        audioSource2.clip = deathEffect;
        audioSource2.Play();
    }
}
