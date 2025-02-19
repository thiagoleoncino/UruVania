using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scr_Boss_1_Proyectil : MonoBehaviour
{
    public float velocityX;

    void Update()
    {
        transform.Translate(Vector3.left * velocityX * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }
}
