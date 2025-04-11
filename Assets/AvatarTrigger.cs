using UnityEngine;
using System.Collections;

public class AvatarTrigger : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;

    public AudioSource audio1; // for LookAround
    public AudioSource audio2; // for Pointing
    public GameObject videoCamera;
    public Transform cameraBagTarget;

    public Transform rootToRotate; // Assign Avatar_cameraman
    public float rotateOffsetAngle = 45f; // Degrees to offset (positive = turn right)

    private Animator animator;
    private bool hasLooked = false;
    private bool hasKnelt = false;

    private Quaternion originalRotation;
    private float rotateSpeed = 2.0f;
    private bool rotatingToBag = false;
    private bool rotatingBack = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (rootToRotate == null)
            rootToRotate = transform;

        originalRotation = rootToRotate.rotation;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!hasLooked && distance <= triggerDistance)
        {
            hasLooked = true;
            animator.SetTrigger("LookAround");
            audio1?.Play();
        }

        if (rotatingToBag)
        {
            RotateTowardWithOffset(cameraBagTarget.position);
        }

        if (rotatingBack)
        {
            RotateBackToOriginal();
        }
    }

    public void OnLookAroundComplete()
    {
        animator.SetTrigger("Idle");
        Invoke(nameof(TriggerPointing), 12f);
    }

    void TriggerPointing()
    {
        animator.SetTrigger("Pointing");
        audio2?.Play();
    }

    public void OnPointingComplete()
    {
        animator.SetTrigger("Kneel");
        rotatingToBag = true;
        Invoke(nameof(StartCameraMovement), 1.5f);
    }

    void StartCameraMovement()
    {
        if (!hasKnelt)
        {
            hasKnelt = true;
            StartCoroutine(SmoothCameraToBag());
        }
    }

    public void OnKneelComplete()
    {
        rotatingToBag = false;
        rotatingBack = true;
    }

    void RotateTowardWithOffset(Vector3 target)
    {
        Vector3 direction = (target - rootToRotate.position).normalized;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion offsetRotation = Quaternion.Euler(0, rotateOffsetAngle, 0);
            Quaternion finalRotation = lookRotation * offsetRotation;

            rootToRotate.rotation = Quaternion.Slerp(rootToRotate.rotation, finalRotation, Time.deltaTime * rotateSpeed);
        }
    }

    void RotateBackToOriginal()
    {
        rootToRotate.rotation = Quaternion.Slerp(rootToRotate.rotation, originalRotation, Time.deltaTime * rotateSpeed);

        if (Quaternion.Angle(rootToRotate.rotation, originalRotation) < 1f)
        {
            rootToRotate.rotation = originalRotation;
            rotatingBack = false;
        }
    }

    IEnumerator SmoothCameraToBag()
    {
        if (videoCamera == null || cameraBagTarget == null) yield break;

        float duration = 2f;
        float elapsed = 0f;

        Vector3 startPos = videoCamera.transform.position;
        Vector3 endPos = cameraBagTarget.position;

        Vector3 startScale = videoCamera.transform.localScale;
        Vector3 endScale = Vector3.zero;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            videoCamera.transform.position = Vector3.Lerp(startPos, endPos, t);
            videoCamera.transform.localScale = Vector3.Lerp(startScale, endScale, t);

            yield return null;
        }

        videoCamera.SetActive(false);
    }
}
