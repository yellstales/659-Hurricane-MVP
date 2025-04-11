using UnityEngine;
using System.Collections;

public class ScreenStateManager : MonoBehaviour
{
    public Texture homeScreen;
    public Texture uploadScreen;
    public Texture completedScreen;

    [Range(0.1f, 3f)]
    public float transitionDuration = 1.0f;

    private MeshRenderer meshRenderer;
    private Coroutine transitionCoroutine;

    private enum ScreenState { Home, Upload, Completed }
    private ScreenState currentState = ScreenState.Home;

    private static readonly string EMISSIVE_TEXTURE = "_emissiveTexture";
    private static readonly string EMISSIVE_FACTOR = "_emissiveFactor";

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        SetTexture(homeScreen, Color.white);
    }

    public void OnHomeScreenClicked()
    {
        if (currentState == ScreenState.Home)
        {
            currentState = ScreenState.Upload;
            StartTransition(uploadScreen);
        }
    }

    public void OnUploadClicked()
    {
        if (currentState == ScreenState.Upload)
        {
            currentState = ScreenState.Completed;
            StartTransition(completedScreen);
        }
    }

    void StartTransition(Texture newTexture)
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);

        transitionCoroutine = StartCoroutine(FadeToTexture(newTexture));
    }

    IEnumerator FadeToTexture(Texture newTexture)
    {
        Material mat = meshRenderer.material;

        Color original = mat.GetColor(EMISSIVE_FACTOR);
        float elapsed = 0f;

        // Fade out
        while (elapsed < transitionDuration / 2f)
        {
            elapsed += Time.deltaTime;
            float t = 1f - Mathf.Clamp01(elapsed / (transitionDuration / 2f));
            mat.SetColor(EMISSIVE_FACTOR, original * t);
            yield return null;
        }

        // Swap texture and fade in
        mat.SetTexture(EMISSIVE_TEXTURE, newTexture);
        elapsed = 0f;

        while (elapsed < transitionDuration / 2f)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / (transitionDuration / 2f));
            mat.SetColor(EMISSIVE_FACTOR, original * t);
            yield return null;
        }

        mat.SetColor(EMISSIVE_FACTOR, original);
        transitionCoroutine = null;
    }

    void SetTexture(Texture texture, Color emissive)
    {
        var mat = meshRenderer.material;
        mat.SetTexture(EMISSIVE_TEXTURE, texture);
        mat.SetColor(EMISSIVE_FACTOR, emissive);
    }
}
