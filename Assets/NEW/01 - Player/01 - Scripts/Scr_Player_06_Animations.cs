using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_06_Animations : MonoBehaviour
{
    private Scr_Player_02_States playerState;


    //Component
    private Animator animator;

    private string actualAnimation;

    private Dictionary<string, string> animationDictionary = new Dictionary<string, string>
    {
        {"Idle",  "Anim_Player_01_Idle" },
        {"Walk",  "Anim_Player_02_Walk" },
        {"Run",  "Anim_Player_03_Run" },
        {"Jump",  "Anim_Player_04_Jump" },
    };

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimation(string newAnimation) //Animation Change
    {
        if (actualAnimation == newAnimation) return;

        animator.Play(newAnimation);
        actualAnimation = newAnimation;
    }

    //Animation finish function
    public bool AnimationFinished(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f;
    }
}
