using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Life : MonoBehaviour
{
    public int life;

    private BoxCollider box;
    private CapsuleCollider capsule;

    public GameObject destroyEffect;
    public Transform effectTransform;

    private void Start()
    {
        box = GetComponentInParent<BoxCollider>();
        capsule = GetComponentInParent<CapsuleCollider>();
    }

    private void Update()
    {
        if (life <= 0)
        {
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
                life -= playerDamageScript.damage;
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
