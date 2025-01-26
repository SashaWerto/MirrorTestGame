using Mirror;
using UnityEngine;

public class Weapon : NetworkBehaviour
{
    [Header("References")]
    public Animator animator;
    [Header("Preferences")]
    public float damage;

    private protected AnimatorStateInfo animState;

    public virtual void Update()
    {
        HandleAnimatorState();
    }

    public void HandleAnimatorState()
    {
        animState = animator.GetCurrentAnimatorStateInfo(0);
    }
}
