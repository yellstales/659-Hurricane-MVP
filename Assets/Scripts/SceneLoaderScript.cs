using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    string triggerTag = "MainCamera";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            Debug.Log("Loading next scene");
            SceneManager.LoadScene("MVP_MAIN");
            
        }
    }
}