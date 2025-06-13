using UnityEngine;
using Cinemachine;

public class Scr_ChangeDirection : MonoBehaviour
{
    [Header("Verde")]
    public Vector3 cameraDirection1;
    public Vector3 cameraRotation1;
    public float spriteRotation1;
    [Space]
    [Header("Rojo")]
    public Vector3 cameraDirection2;
    public Vector3 cameraRotation2;
    public float spriteRotation2;

    private Transform triggerTransform;
    private Vector3 localLineStart;
    private Vector3 localLineEnd;

    private Transform playerCameraDisplay;
    private Transform playerSprites;

    private bool playerInside = false;
    private bool isFinishingTransition = false;

    private Quaternion finalTargetRot;
    private float finalTargetYRot;
    private Vector3 finalTrackedOffset;

    private float rotationSpeed = 20f;

    // Cinemachine
    private CinemachineVirtualCamera virtualCam;
    private CinemachineFramingTransposer framingTransposer;

    private void Start()
    {
        triggerTransform = transform;

        if (GetComponent<Collider>() is BoxCollider box)
        {
            Vector3 size = box.size;
            localLineStart = new Vector3(0, 0, -size.z * 0.5f);
            localLineEnd = new Vector3(0, 0, size.z * 0.5f);
        }

        virtualCam = FindObjectOfType<CinemachineVirtualCamera>();
        if (virtualCam != null)
        {
            framingTransposer = virtualCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Transform player = other.transform;
        playerCameraDisplay = player.Find("Player_Camara");
        playerSprites = player.Find("Player_Axis");

        playerInside = true;
        isFinishingTransition = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (playerCameraDisplay == null || playerSprites == null || framingTransposer == null) return;

        Vector3 worldLineStart = triggerTransform.TransformPoint(localLineStart);
        Vector3 worldLineEnd = triggerTransform.TransformPoint(localLineEnd);
        Vector3 playerPos = other.transform.position;

        Vector3 lineDir = (worldLineEnd - worldLineStart).normalized;
        float totalLength = Vector3.Distance(worldLineStart, worldLineEnd);
        float projection = Vector3.Dot(playerPos - worldLineStart, lineDir);
        float t = Mathf.Clamp01(projection / totalLength);

        finalTargetRot = Quaternion.Slerp(Quaternion.Euler(cameraRotation1), Quaternion.Euler(cameraRotation2), t);
        finalTargetYRot = Mathf.LerpAngle(spriteRotation1, spriteRotation2, t);
        finalTrackedOffset = Vector3.Lerp(cameraDirection1, cameraDirection2, t);

        playerInside = false;
        isFinishingTransition = true;
    }

    private void LateUpdate()
    {
        if (playerCameraDisplay == null || playerSprites == null || framingTransposer == null) return;

        if (playerInside)
        {
            Vector3 worldLineStart = triggerTransform.TransformPoint(localLineStart);
            Vector3 worldLineEnd = triggerTransform.TransformPoint(localLineEnd);

            Vector3 playerPos = playerCameraDisplay.parent.position;

            Vector3 lineDir = (worldLineEnd - worldLineStart).normalized;
            float totalLength = Vector3.Distance(worldLineStart, worldLineEnd);
            float projection = Vector3.Dot(playerPos - worldLineStart, lineDir);
            float t = Mathf.Clamp01(projection / totalLength);

            Quaternion targetRot = Quaternion.Slerp(Quaternion.Euler(cameraRotation1), Quaternion.Euler(cameraRotation2), t);
            float targetYRot = Mathf.LerpAngle(spriteRotation1, spriteRotation2, t);
            Vector3 targetTrackedOffset = Vector3.Lerp(cameraDirection1, cameraDirection2, t);

            // Cámara (rotación local del objeto cámara)
            playerCameraDisplay.localRotation = Quaternion.Slerp(playerCameraDisplay.localRotation, targetRot, Time.deltaTime * rotationSpeed);

            // Cinemachine offset (Framing Transposer)
            framingTransposer.m_TrackedObjectOffset = Vector3.Lerp(
                framingTransposer.m_TrackedObjectOffset,
                targetTrackedOffset,
                Time.deltaTime * 5f
            );

            // Rotación del sprite (Y)
            Vector3 currentSpriteEuler = playerSprites.localEulerAngles;
            currentSpriteEuler.y = Mathf.LerpAngle(currentSpriteEuler.y, targetYRot, Time.deltaTime * rotationSpeed);
            playerSprites.localEulerAngles = currentSpriteEuler;
        }
        else if (isFinishingTransition)
        {
            // Cámara
            playerCameraDisplay.localRotation = Quaternion.Slerp(playerCameraDisplay.localRotation, finalTargetRot, Time.deltaTime * rotationSpeed);

            // Offset final
            framingTransposer.m_TrackedObjectOffset = Vector3.Lerp(
                framingTransposer.m_TrackedObjectOffset,
                finalTrackedOffset,
                Time.deltaTime * 5f
            );

            // Rotación del sprite
            Vector3 currentSpriteEuler = playerSprites.localEulerAngles;
            currentSpriteEuler.y = Mathf.LerpAngle(currentSpriteEuler.y, finalTargetYRot, Time.deltaTime * rotationSpeed);
            playerSprites.localEulerAngles = currentSpriteEuler;

            if (Quaternion.Angle(playerCameraDisplay.localRotation, finalTargetRot) < 0.5f &&
                Mathf.Abs(Mathf.DeltaAngle(playerSprites.localEulerAngles.y, finalTargetYRot)) < 0.5f &&
                Vector3.Distance(framingTransposer.m_TrackedObjectOffset, finalTrackedOffset) < 0.05f)
            {
                playerCameraDisplay.localRotation = finalTargetRot;
                framingTransposer.m_TrackedObjectOffset = finalTrackedOffset;

                Vector3 finalSpriteEuler = playerSprites.localEulerAngles;
                finalSpriteEuler.y = finalTargetYRot;
                playerSprites.localEulerAngles = finalSpriteEuler;

                isFinishingTransition = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Collider col = GetComponent<Collider>();
        if (col is BoxCollider box)
        {
            Transform tf = transform;
            Vector3 size = box.size;
            Vector3 center = box.center;

            Vector3 localStart = new Vector3(0, 0, -size.z * 0.5f);
            Vector3 localEnd = new Vector3(0, 0, size.z * 0.5f);

            Vector3 worldStart = tf.TransformPoint(center + localStart);
            Vector3 worldEnd = tf.TransformPoint(center + localEnd);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(worldStart, worldEnd);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(worldStart, 0.1f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(worldEnd, 0.1f);
        }
    }
}