using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Scr_Boss_Life : MonoBehaviour
{
    public float actualLife = 1f;
    public float totalLife;
    public Image liferBar;
    public bool intro;

    private BoxCollider box;
    private CapsuleCollider capsule;
    
    public GameObject destroyEffect;
    public Transform effectTransform;
    private Scr_Scene_Manager musicScript;

    private void Start()
    {
        box = GetComponentInParent<BoxCollider>();
        capsule = GetComponentInParent<CapsuleCollider>();
        musicScript = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<Scr_Scene_Manager>();
    }

    private void Update()
    {
        liferBar.fillAmount = actualLife / totalLife;

        if (intro)
        {
            actualLife = Mathf.Lerp(actualLife, totalLife, Time.deltaTime * 2f);
        }
        if (actualLife >= totalLife - 1)
        {
            intro = false;
        }

        if (actualLife <= 0)
        {
            musicScript.stopMusic();

            if (box != null)
                box.enabled = false;

            if (capsule != null)
                capsule.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            Scr_Player_Damage playerDamageScript = other.gameObject.GetComponent<Scr_Player_Damage>();
            if (playerDamageScript != null)
            {
                actualLife -= playerDamageScript.damage;
            }
        }
    }

    public void deathEffect()
    {
        Vector3 scale = effectTransform.localScale;
        Vector3 newScale = new Vector3(scale.x * destroyEffect.transform.localScale.x,
                                       scale.y * destroyEffect.transform.localScale.y,
                                       scale.z * destroyEffect.transform.localScale.z);

        GameObject instantiatedEffect = Instantiate(destroyEffect, effectTransform.position, effectTransform.rotation);
        instantiatedEffect.transform.localScale = newScale;
        Destroy(gameObject);
    }
}
