using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChecklist : MonoBehaviour
{
    public GameObject canvas; // Assign UI Panel in Inspector

    void Start()
    {
        if (canvas != null)
            canvas.SetActive(false); // Ensure the panel is hidden at the start
    }

    public void TogglePanel()
    {
        if (canvas != null)
            canvas.SetActive(!canvas.activeSelf); // Toggle visibility when poked
    }



    // public GameObject uiPanel; // Assign UI Panel in Inspector

    // void Start()
    // {
    //     if (uiPanel != null)
    //         uiPanel.SetActive(false); // Hide UI panel at the start
    // }

    // public void ShowPanel()
    // {
    //     if (uiPanel != null)
    //         uiPanel.SetActive(true); // Show panel when touching
    // }

    // public void HidePanel()
    // {
    //     if (uiPanel != null)
    //         uiPanel.SetActive(false); // Hide panel when not touching
    // }



    // public GameObject uiPanel;  // Assign the UI Panel in Inspector

    // void Start()
    // {
    //     if (uiPanel != null)
    //         uiPanel.SetActive(false); // Hide panel at start
    // }

    // public void OnChecklistClicked()
    // {
    //     if (uiPanel != null)
    //     {
    //         bool isActive = uiPanel.activeSelf;
    //         uiPanel.SetActive(!isActive); // Toggle panel visibility
    //     }
    // }
}