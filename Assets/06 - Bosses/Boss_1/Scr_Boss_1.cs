using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TipoAccion
{
    action0,
    action1,
    action2,
    action3,
    action4,
    death
}

public class Scr_Boss_1 : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    public float velocity;
    public GameObject proyectil;
    public Transform position;
    public float responseTime;

    public TipoAccion actualState;
    private Scr_Boss_Life scriptLife;
    public bool intro;

    private Scr_Scene_Manager musicScript;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        scriptLife = GetComponent<Scr_Boss_Life>();
        musicScript = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<Scr_Scene_Manager>();

        int capaObjetoActual = gameObject.layer;
        int capaObjetosAIgnorear = LayerMask.NameToLayer("Platform");
        Physics.IgnoreLayerCollision(capaObjetoActual, capaObjetosAIgnorear, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptLife.actualLife > 0)
        {
            if (intro && actualState == TipoAccion.action0)
            {
                animator.Play("Anim_Boss1_Intro");
            }

            if (actualState == TipoAccion.action1)
            {
                animator.Play("Anim_Boss1_Walk");
                rigidBody.velocity = new Vector3(-velocity, rigidBody.velocity.y, rigidBody.velocity.z);
            }

            if (actualState == TipoAccion.action2)
            {
                animator.Play("Anim_Boss1_Attk_Melee");
            }

            if (actualState == TipoAccion.action3)
            {
                animator.Play("Anim_Boss1_Attk_Proyectil");
            }

        }
        else
        {
            animator.Play("Anim_Boss1_Deathanim");
            rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, rigidBody.velocity.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            if (actualState == TipoAccion.action1)
            {
                turnAround();
            }
        }
    }

    void turnAround()
    {
        velocity = -velocity;
        float newRotationY = (Mathf.Approximately(transform.rotation.eulerAngles.y, 0f)) ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0f, newRotationY, 0f);
        Invoke("CambiarEstado", responseTime);
    }

    void CambiarEstado()
    {
        actualState = TipoAccion.action3;
    }

    public void Proyectil()
    {
        Instantiate(proyectil, position.position, position.rotation);
    }

    public void backToIdle()
    {
        actualState = TipoAccion.action1;
    }

    public void lifeCharge()
    {
        scriptLife.intro = true;
    }

    public void musciIntro()
    {
        musicScript.bossStart();
    }
}
