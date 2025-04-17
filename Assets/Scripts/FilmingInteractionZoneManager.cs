using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilmingInteractionZoneManager : MonoBehaviour
{
    public string avatarTag = "MainCamera";
    public GameObject messageCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(avatarTag))
        {
            StartCoroutine(TriggerCanvas());
        }
    }

    private IEnumerator TriggerCanvas()
    {
        messageCanvas.SetActive(true);
        yield return new WaitForSeconds(4f);
        messageCanvas.SetActive(false);
    }
}
