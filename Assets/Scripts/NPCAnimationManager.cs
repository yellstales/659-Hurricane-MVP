using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCAnimationManager : MonoBehaviour
{
    GameObject npcCharacter;
    public Animator animator;
    InteractableUnityEventWrapper wrapper;

    bool isHovering = false;

    void Start()
    {
        npcCharacter = GameObject.FindGameObjectsWithTag("npc")[0];
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        wrapper = npcCharacter.GetComponent<InteractableUnityEventWrapper>();
        wrapper.WhenHover.AddListener(OnHover);
    }

    void OnHover() {

        if (!isHovering) {
            animator.SetBool("isWaving", true);
            isHovering = true;
            StartCoroutine(ResetHoverFlagAfterDelay());
        }
    }

    private IEnumerator ResetHoverFlagAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        isHovering = false;
        animator.SetBool("isWaving", false);
    }

}
