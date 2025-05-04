using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ChangeDirection : MonoBehaviour
{
    public float Direction1; // Izquierda a derecha
    public float Direction2; // Derecha a izquierda
    [Space]
    public bool changeSpriteDirection;
    public float SpriteDirection1;
    public float SpriteDirection2;
    [Space]
    public bool changeCameraDirection;
    [Space]
    public Vector3 cameraDirection1;
    public Vector3 cameraRotation1;
    [Space]
    public Vector3 cameraDirection2;
    public Vector3 cameraRotation2;

    private Dictionary<GameObject, float> lastDotResults = new Dictionary<GameObject, float>();
    private Dictionary<GameObject, InterpolationData> interpolationTargets = new Dictionary<GameObject, InterpolationData>();

    private Transform triggerTransform;
    private Vector3 localLineStart;
    private Vector3 localLineEnd;

    private class InterpolationData
    {
        public Transform sprite;
        public Transform cameraDisplay;
        public Quaternion targetSpriteRotation;
        public Vector3 targetCameraPosition;
        public Quaternion targetCameraRotation;
    }

    private void Start()
    {
        triggerTransform = transform;

        BoxCollider box = GetComponent<Collider>() as BoxCollider;
        if (box != null)
        {
            Vector3 size = box.size;
            localLineStart = new Vector3(0, 0, -size.z * 0.5f);
            localLineEnd = new Vector3(0, 0, size.z * 0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Vector3 worldLineStart = triggerTransform.TransformPoint(localLineStart);
        Vector3 worldLineEnd = triggerTransform.TransformPoint(localLineEnd);
        Vector3 playerPos = other.transform.position;

        Vector3 lineDir = (worldLineEnd - worldLineStart).normalized;
        Vector3 toPlayer = playerPos - worldLineStart;

        float crossZ = lineDir.x * toPlayer.z - lineDir.z * toPlayer.x;

        if (lastDotResults.TryGetValue(other.gameObject, out float lastCross))
        {
            if (lastCross * crossZ < 0) // Cambió de lado
            {
                float currentY = other.transform.eulerAngles.y;

                if (Mathf.Abs(Mathf.DeltaAngle(currentY, Direction1)) < 1f)
                {
                    SetYRotation(other.gameObject, Direction2);

                    InterpolationData data = GetOrCreateInterpolationData(other);

                    if (changeSpriteDirection && data.sprite != null)
                        data.targetSpriteRotation = Quaternion.Euler(0, SpriteDirection2, 0);

                    if (changeCameraDirection && data.cameraDisplay != null)
                    {
                        data.targetCameraPosition = cameraDirection2;
                        data.targetCameraRotation = Quaternion.Euler(cameraRotation2);
                    }
                }
                else if (Mathf.Abs(Mathf.DeltaAngle(currentY, Direction2)) < 1f)
                {
                    SetYRotation(other.gameObject, Direction1);

                    InterpolationData data = GetOrCreateInterpolationData(other);

                    if (changeSpriteDirection && data.sprite != null)
                        data.targetSpriteRotation = Quaternion.Euler(0, SpriteDirection1, 0);

                    if (changeCameraDirection && data.cameraDisplay != null)
                    {
                        data.targetCameraPosition = cameraDirection1;
                        data.targetCameraRotation = Quaternion.Euler(cameraRotation1);
                    }
                }

                lastDotResults[other.gameObject] = crossZ + 0.01f * Mathf.Sign(crossZ);
            }
            else
            {
                lastDotResults[other.gameObject] = crossZ;
            }
        }
        else
        {
            lastDotResults.Add(other.gameObject, crossZ);
        }
    }

    private InterpolationData GetOrCreateInterpolationData(Collider other)
    {
        if (!interpolationTargets.TryGetValue(other.gameObject, out var data))
        {
            data = new InterpolationData();
            data.sprite = other.transform.Find("Player_Sprites");
            data.cameraDisplay = other.transform.Find("Camera Player Display");

            if (data.sprite != null)
                data.targetSpriteRotation = data.sprite.localRotation;
            if (data.cameraDisplay != null)
            {
                data.targetCameraPosition = data.cameraDisplay.localPosition;
                data.targetCameraRotation = data.cameraDisplay.localRotation;
            }

            interpolationTargets[other.gameObject] = data;
        }
        return data;
    }

    private void LateUpdate()
    {
        foreach (var kvp in interpolationTargets)
        {
            InterpolationData data = kvp.Value;

            if (changeSpriteDirection && data.sprite != null)
            {
                data.sprite.localRotation = Quaternion.Lerp(data.sprite.localRotation, data.targetSpriteRotation, Time.deltaTime * 5f);
            }

            if (changeCameraDirection && data.cameraDisplay != null)
            {
                data.cameraDisplay.localPosition = Vector3.Lerp(data.cameraDisplay.localPosition, data.targetCameraPosition, Time.deltaTime * 5f);
                data.cameraDisplay.localRotation = Quaternion.Lerp(data.cameraDisplay.localRotation, data.targetCameraRotation, Time.deltaTime * 5f);
            }
        }
    }

    private void SetYRotation(GameObject target, float yRotation)
    {
        Vector3 euler = target.transform.localEulerAngles;
        euler.y = yRotation;
        target.transform.localEulerAngles = euler;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lastDotResults.Remove(other.gameObject);
            interpolationTargets.Remove(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Collider col = GetComponent<Collider>();
        if (col == null) return;

        Vector3 center = col.bounds.center;

        BoxCollider box = col as BoxCollider;
        if (box != null)
        {
            Vector3 size = box.size;
            Transform tf = transform;

            Vector3 start = tf.TransformPoint(new Vector3(0, 0, -size.z * 0.5f));
            Vector3 end = tf.TransformPoint(new Vector3(0, 0, size.z * 0.5f));

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(start, end);
            Gizmos.DrawSphere(start, 0.05f);
            Gizmos.DrawSphere(end, 0.05f);
        }

        Gizmos.color = Color.green;
        Vector3 dir1 = Quaternion.Euler(0, Direction1 + 90f, 0) * Vector3.forward;
        Gizmos.DrawLine(center, center + dir1 * 2f);
        Gizmos.DrawSphere(center + dir1 * 2f, 0.05f);

        Gizmos.color = Color.red;
        Vector3 dir2 = Quaternion.Euler(0, Direction2 + 270f, 0) * Vector3.forward;
        Gizmos.DrawLine(center, center + dir2 * 2f);
        Gizmos.DrawSphere(center + dir2 * 2f, 0.05f);
    }
}