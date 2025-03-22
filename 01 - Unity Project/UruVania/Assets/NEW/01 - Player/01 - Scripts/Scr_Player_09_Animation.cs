using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scr_Player_09_Animation : MonoBehaviour
{
    // Scripts Variables
    private Scr_Player_02_State playerState;
    private Scr_Player_03_Statistics playerStatistics;
    private Scr_Player_06_Combat playerCombat;

    // Componentes
    private Animator animator;
    public string actualAnimation;

    // Diccionario de Animaciones
    private Dictionary<string, string> animationDictionary = new Dictionary<string, string>
    {
        { "Animation_Idle", "Anim_Player_01_Idle" },
        { "Animation_Walk", "Anim_Player_02_Walk" },
        { "Animation_Run", "Anim_Player_03_Run" },
        { "Animation_Jump", "Anim_Player_04_Jump" },
        { "Animation_DoubleJump", "Anim_Player_05_DoubleJump" },
        { "Animation_Fall", "Anim_Player_06_Fall" },
        { "Animation_Land", "Anim_Player_07_Land" },

        { "Animation_NormalAttack1", "Anim_Player_08_NormalAttack1" },
        { "Animation_NormalAttack2", "Anim_Player_09_NormalAttack2" },
        { "Animation_ChargingNormal", "Anim_Player_10_ChargingNormal" },
        { "Animation_NormalChargeAttack", "Anim_Player_11_NormalChargeAttack" },
        { "Animation_NormalJumpAttack", "Anim_Player_12_NormalJumpAttack" },
        { "Animation_NormalDashAttack", "Anim_Player_13_NormalDashAttack" },

        { "Animation_PonchoAttack", "Anim_Player_14_PonchoAttack" },
        { "Animation_ChargingPoncho", "Anim_Player_15_ChargingPoncho" },
        { "Animation_PonchoChargeAttack", "Anim_Player_16_PonchoChargeAttack" },
        { "Animation_PonchoJumpAttack", "Anim_Player_17_PonchoJumpAttack" },
        { "Animation_Dodge", "Anim_Player_18_Dodge" },

        { "Animation_GroundHit", "Anim_Player_19_GroundHit" },
        { "Animation_AirHit", "Anim_Player_20_AirHit" }
    };


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerState = GetComponentInParent<Scr_Player_02_State>();
        playerStatistics = GetComponentInParent<Scr_Player_03_Statistics>();
        playerCombat = GetComponentInParent<Scr_Player_06_Combat>();
    }

    // Cambiar Animación usando el Diccionario
    public void ChangeAnimationFunction(string animationKey)
    {
        if (!animationDictionary.TryGetValue(animationKey, out string newAnimation))
        {
            Debug.LogWarning($"Animación '{animationKey}' no encontrada en el diccionario.");
            return;
        }

        if (actualAnimation == newAnimation) return;

        animator.Play(newAnimation);
        actualAnimation = newAnimation;
    }

    // Comprobar si una animación ha alcanzado cierto punto
    public bool AnimationEventFunction(string animationKey, float animationEventTime)
    {
        if (!animationDictionary.TryGetValue(animationKey, out string animationName))
        {
            Debug.LogWarning($"Animación '{animationKey}' no encontrada en el diccionario.");
            return false;
        }

        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationEventTime;
    }

    // Eventos del Animator
    public void EventAttackCanBeCanceled()
    {
        if (playerStatistics.playerActualComboCount < playerStatistics.playerMaxCombo)
        {
            playerCombat.attackCanBeCancel = true;
        }
    }

    public void EventDeactivateCollision()
    {
        playerState.invulnerableCombatAction = true;
    }

    public void EventActivateCollision()
    {
        playerState.normalCombatAction = true;
    }
}
