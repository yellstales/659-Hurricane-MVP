using UnityEngine;

public class PlayerProximityTrigger : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float triggerDistance = 3.0f;
    private bool triggered = false;

    void Update()
    {
        if (!triggered && Vector3.Distance(player.position, transform.position) < triggerDistance)
        {
            animator.SetTrigger("playerClose");
            triggered = true;
        }
    }
}
