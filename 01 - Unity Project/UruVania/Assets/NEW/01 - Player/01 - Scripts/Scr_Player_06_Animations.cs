using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_06_Animations : MonoBehaviour
{
    //Component
    private Animator animator;
    public string actualAnimation;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //Animation change
    public void ChangeAnimationFunction(string newAnimation)
    {
        if (actualAnimation == newAnimation) return;

        animator.Play(newAnimation);
        actualAnimation = newAnimation;
    }

    //Animation finish function
    public bool AnimationEventFunction(string animationName, float animationEventTime)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationEventTime;
    }

}