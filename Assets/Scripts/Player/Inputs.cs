using System;
using UnityEngine;
using Mirror;

public class Inputs : NetworkBehaviour
{
    [Header("References")]
    public static float horizontalInput;
    public static float verticalInput;
    public static float mouseWheel;
    public static float mouseAngle;
    public static Action OnPrimaryDownAction;
    public static Action OnInteractDownAction;
    public static Action OnPrimaryUpAction;
    public static Action OnPrimaryHoldAction;
    public static Action OnSecondaryDownAction;
    public static Action OnSecondaryUpAction;
    public static Action OnSecondaryHoldAction;
    public static Action OnDownSprint;
    public static Action OnUpSprint;
    public static Action OnReloadAction;
    public static Action OnJumpAction;
    public static Action OnDownCrouch;
    public static Action OnUpCrouch;
    public static Action OnFlashlight;

    void Update()
    {
        if (!isLocalPlayer) return;
        if (!InputsHandler.inputsBlocked)
        {
            BusyActions();
            CombatActions();
        }
        HandleInput();
    }
    
    private void HandleInput()
    {
        if (!InputsHandler.inputsBlocked)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            mouseWheel = Input.GetAxis("Mouse ScrollWheel");
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouseAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
        else
        {
            horizontalInput = 0;
            verticalInput = 0;
            mouseWheel = 0;
        }
    }
    private void CombatActions()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnPrimaryDownAction?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnPrimaryUpAction?.Invoke();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnPrimaryHoldAction?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnSecondaryDownAction?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            OnSecondaryUpAction?.Invoke();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            OnSecondaryHoldAction?.Invoke();
        }
    }
    private void BusyActions()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnInteractDownAction?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            OnFlashlight?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReloadAction?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpAction?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnDownSprint?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OnUpSprint?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnDownCrouch?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            OnUpCrouch?.Invoke();
        }
    }
}
