using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scr_Drop_Item : MonoBehaviour
{
    public bool noDrop;

    public GameObject destroyEffect;
    public GameObject[] dropItems;

    private Scr_Audio_Destroy audioDestroy;

    private void Start()
    {
        audioDestroy = GetComponent<Scr_Audio_Destroy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, transform.rotation);
            DropItem();
        }
    }

    public void DropItem()
    {
        if (!noDrop && dropItems.Length > 0)
        {
            float totalWeight = dropItems.Length;

            float randomValue = Random.value * totalWeight;

            float cumulativeWeight = 0;

            for (int i = 0; i < dropItems.Length; i++)
            {
                cumulativeWeight += 1;

                if (randomValue <= cumulativeWeight)
                {
                    Instantiate(dropItems[i], transform.position, transform.rotation);
                    break;
                }
            }
        }

        audioDestroy.DestroyEffect();
    }
}
