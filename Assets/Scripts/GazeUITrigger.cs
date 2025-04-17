using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeUITrigger : MonoBehaviour
{
    public GameObject uiPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GazePointer"))
        {
            uiPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GazePointer"))
        {
            uiPanel.SetActive(false);
        }
    }
}

