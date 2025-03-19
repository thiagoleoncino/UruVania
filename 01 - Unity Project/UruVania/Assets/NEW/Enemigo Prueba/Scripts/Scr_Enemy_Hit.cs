using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Hit : MonoBehaviour
{
    private Animator animator;
    private int playerHitboxLayer;
    public bool hitDetected;
    public string actualAnimation;
    public int hitCount;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerHitboxLayer = LayerMask.NameToLayer("Layer_PlayerHitbox"); // Obtiene el índice de la capa
    }

    private void Update()
    {
        if(hitDetected)
        {
            ChangeAnimationFunction("Anim_Enemy_05_Damage");
        }
        else { ChangeAnimationFunction("Anim_Enemy_01_Idle_N");  }

        if(AnimationEventFunction("Anim_Enemy_05_Damage", 0.95f))
        {
            hitDetected = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerHitboxLayer)
        {
            hitDetected = true;
            hitCount++; // Incrementa el contador de golpes

            // Si el enemigo ya está en la animación de daño, reiniciar la animación
            if (actualAnimation == "Anim_Enemy_05_Damage")
            {
                animator.Play("Anim_Enemy_05_Damage", 0, 0f); // Reinicia la animación
            }
        }
    }

    public void ChangeAnimationFunction(string animationKey)
    {
        if (actualAnimation == animationKey) return;

        animator.Play(animationKey);
        actualAnimation = animationKey;
    }

    // Comprobar si una animación ha alcanzado cierto punto
    public bool AnimationEventFunction(string animationKey, float animationEventTime)
    {

        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationKey) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationEventTime;
    }
}
