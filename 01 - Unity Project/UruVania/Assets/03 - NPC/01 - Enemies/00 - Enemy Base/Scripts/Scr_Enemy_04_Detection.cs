using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class Scr_Enemy_04_Detection : MonoBehaviour
{
    //Script Variables
    public MonoBehaviour targetScript1;
    public string functionName1; 
    [Space]
    public bool onTriggerExit;
    public MonoBehaviour targetScript2;
    public string functionName2; 
    [Space]
    public BoxCollider triggerCollider; 
    [Space]
    public bool disableAfterTrigger; 
    [Space]
    private Vector3 originalColliderSize;
    public Vector3 newColliderSize = new Vector3(1f, 1f, 1f);

    private void Start()
    {
        if (triggerCollider != null)
        {
            originalColliderSize = triggerCollider.size;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Layer_Player"))
        {
            TriggerEvent(targetScript1, functionName1);
            triggerCollider.size = newColliderSize;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Layer_Player") && onTriggerExit)
        {
            TriggerEvent(targetScript2, functionName2);
            triggerCollider.size = originalColliderSize;
        }
    }


    public void TriggerEvent(MonoBehaviour script, string function)
    {
        if (script != null && !string.IsNullOrEmpty(function))
        {
            MethodInfo method = script.GetType().GetMethod(function, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (method != null)
            {
                method.Invoke(script, null);
            }
            else
            {
                Debug.LogWarning($"Método {function} no encontrado en {script.GetType().Name}");
            }

            if (disableAfterTrigger)
            {
                Destroy(triggerCollider.gameObject);
                Destroy(this);
            }
        }
    }

}