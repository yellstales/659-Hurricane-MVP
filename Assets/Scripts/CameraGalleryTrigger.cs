using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCanvasInFront : MonoBehaviour
{
    public GameObject galleryUI;
    public float distanceFromCamera = 1.5f;

    public void ToggleGallery()
    {
        if (galleryUI == null) return;

        if (galleryUI.activeSelf)
        {
            // If visible, hide it
            galleryUI.SetActive(false);
        }
        else
        {
            // If hidden, move and show it in front of the user
            Transform userView = Camera.main != null ? Camera.main.transform : null;
            if (userView == null) return;

            Vector3 spawnPos = userView.position + userView.forward * distanceFromCamera;
            Quaternion lookRot = Quaternion.LookRotation(userView.forward);

            galleryUI.transform.position = spawnPos;
            galleryUI.transform.rotation = lookRot;
            galleryUI.SetActive(true);
        }
    }
}

