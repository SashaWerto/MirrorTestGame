using UnityEngine;
using Mirror;

public class Character_Animations : NetworkBehaviour
{
    [Header("References")]
    public Rigidbody2D rigidbody;
    public Animator animator;
    public FlipToMousePos flipByMouse;
    private void Update()
    {
        if(!isLocalPlayer) return;
        if (rigidbody.velocity.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        HandleFlip();
    }

    private void HandleFlip()
    {
        if (flipByMouse.lookingRight)
        {
            if (Inputs.horizontalInput < 0)
            {
                animator.SetFloat("backward", 1);
            }
            else if(Inputs.horizontalInput > 0)
            {
                animator.SetFloat("backward", 0);
            }
        }
        else
        {
            if (Inputs.horizontalInput > 0)
            {
                animator.SetFloat("backward", 1);
            }
            else if(Inputs.horizontalInput < 0)
            {
                animator.SetFloat("backward", 0);
            }
        }
    }
}
