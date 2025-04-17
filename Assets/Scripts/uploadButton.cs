using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UploadButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText; // Drag in the TMP text object

    private bool isUploaded = false;

    public void OnUploadClicked()
    {
        if (!isUploaded)
        {
            // Simulate upload process (optional delay/feedback)
            buttonText.text = "Uploaded";  // Replace text with checkmark
            isUploaded = true;
        }
    }
}
