using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for UI interactions

public class ShowPanel : MonoBehaviour
{
    public GameObject uiPanel; // Assign your UI panel in the Inspector

    void Start()
    {
        uiPanel.SetActive(false); // Ensure panel starts hidden
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the correct tag
        {
            uiPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false);
        }
    }
}

