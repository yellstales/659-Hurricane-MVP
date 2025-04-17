using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class HandleVisualFeedback : MonoBehaviour
{
    [Header("Color Highlight")]
    public Color defaultColor = Color.gray;
    public Color highlightColor = Color.white;

    private Material handleMaterial;
    private Color currentTargetColor;
    private bool isHovering = false;
    private float colorLerpSpeed = 6f;

    [Header("Handle Rotation")]
    public float rotateAngle = 7f;              // Degrees to rotate on grab
    public float rotateSpeed = 5f;

    private Quaternion originalRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        handleMaterial = renderer.material;
        handleMaterial.color = defaultColor;
        currentTargetColor = defaultColor;

        originalRotation = transform.localRotation;
        targetRotation = originalRotation;
    }

    void Update()
    {
        // Smoothly change color
        handleMaterial.color = Color.Lerp(handleMaterial.color, currentTargetColor, Time.deltaTime * colorLerpSpeed);

        // Smooth rotation
        if (isRotating)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotateSpeed);

            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.5f)
            {
                transform.localRotation = targetRotation;
                isRotating = false;
            }
        }
    }

    // Called from Interactable Unity Event Wrapper (hover)
    public void OnHoverEnter()
    {
        isHovering = true;
        currentTargetColor = highlightColor;
    }

    public void OnHoverExit()
    {
        isHovering = false;
        currentTargetColor = defaultColor;
    }

    // Called from Interactable Unity Event Wrapper (grab)
    public void OnGrab()
    {
        targetRotation = originalRotation * Quaternion.Euler(0f, -rotateAngle, 0f);  // Negative for turning left
        isRotating = true;
    }

    // Called from Interactable Unity Event Wrapper (release)
    public void OnRelease()
    {
        targetRotation = originalRotation;
        isRotating = true;
    }
}
