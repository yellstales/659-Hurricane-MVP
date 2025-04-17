using UnityEngine;

public class ScreenStateManager : MonoBehaviour
{
    public Texture homeScreen;
    public Texture uploadScreen;
    public Texture completedScreen;

    public AudioSource uploadSound; // Assign an AudioSource in the Inspector

    private MeshRenderer meshRenderer;
    private enum ScreenState { Home, Upload, Completed }
    private ScreenState currentState = ScreenState.Home;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", homeScreen);
    }

    public void OnHomeScreenClicked()
    {
        if (currentState == ScreenState.Home)
        {
            currentState = ScreenState.Upload;
            meshRenderer.material.SetTexture("_MainTex", uploadScreen);
        }
    }

    public void OnUploadClicked()
    {
        if (currentState == ScreenState.Upload)
        {
            currentState = ScreenState.Completed;
            meshRenderer.material.SetTexture("_MainTex", completedScreen);

            // Play upload confirmation sound
            if (uploadSound != null)
            {
                uploadSound.Play();
            }
        }
    }
}
