using UnityEngine;
using Mirror;
public class FlipToMousePos : NetworkBehaviour
{
    public bool freeze = false;
    [HideInInspector] public bool lookingRight;
    private void Update()
    {
        if(freeze || !isLocalPlayer) return;
        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            lookingRight = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            lookingRight = true;
        }
    }
}
