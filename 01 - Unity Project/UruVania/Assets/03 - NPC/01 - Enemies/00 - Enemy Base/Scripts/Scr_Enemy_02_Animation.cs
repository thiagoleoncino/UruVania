using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_02_Animation : MonoBehaviour
{
    //Basci Variables
    private Animator animator;
    public string actualAnimation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Change animation by string
    public void ChangeAnimationFunction(string animationKey)
    {
        if (actualAnimation == animationKey) return;

        animator.Play(animationKey);
        actualAnimation = animationKey;
    }

    //Animation finish function
    public bool AnimationEventFunction(string animationKey, float animationEventTime)
    {

        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationKey) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationEventTime;
    }

    //Reset animation function
    public void ResetAnimationFunction(string animationKey)
    {
        animator.Play(animationKey, 0, 0f); 

    }
}
