using UnityEngine;

public static class InputsHandler
{
    private static int windowsCount = 0;
    public static bool inputsBlocked = false;
    public static void ChangeState(bool state)
    {
        if (state)
        {
            windowsCount++;
        }
        else
        { 
            windowsCount = Mathf.Clamp(windowsCount - 1, 0, 100);
        }

        if (windowsCount > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inputsBlocked = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inputsBlocked = false;
        }
    }
}
