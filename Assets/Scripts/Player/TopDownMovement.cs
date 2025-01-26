using UnityEngine;
using Mirror;
public class TopDownMovement : NetworkBehaviour
{
    [Header("References")]
    public Rigidbody2D rigidbody;
    [Header("Player Settings")]
    [SerializeField] private float speed;
    private Vector2 moveDirection;
    private void Update()
    {
        if(!isLocalPlayer) return;
        moveDirection = transform.up * Inputs.verticalInput + transform.right * Inputs.horizontalInput;
    }

    private void FixedUpdate()
    {
        Vector2 normVector = new Vector2(moveDirection.x, moveDirection.y).normalized;
        rigidbody.velocity = normVector * speed;
    }
}
