using GLTFast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamRunFromInitialPosition : MonoBehaviour
{
    public float delayBeforeRun = 10f;
    public float runDuration = 10f;
    public float speed = 5f;
    public Animator animator;
    public Vector3 runDirection = Vector3.forward;
    public string runningAvatarTag;

    GameObject runningAvatar;

    private bool isRunning = false;
    void Start()
    {
        runningAvatar = GameObject.FindGameObjectWithTag(runningAvatarTag);
        StartCoroutine(RunAndDeactivate());
    }
    IEnumerator RunAndDeactivate()
    {
        Debug.Log("in run and deactivate");
        yield return new WaitForSeconds(delayBeforeRun);
        isRunning = true;
        Debug.Log("isRunning true");
        if (animator != null)
        {
            animator.SetBool("IsRunning", true); 
        }

        yield return new WaitForSeconds(runDuration);

        gameObject.SetActive(false);
    }
    void Update()
    {
        if (isRunning)
        {
            runningAvatar.transform.Translate(runDirection * speed * Time.deltaTime);
        }
    }
}
