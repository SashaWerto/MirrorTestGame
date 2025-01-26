using UnityEngine;

public class BlockInputs : MonoBehaviour
{
    private void OnEnable()
    {
        InputsHandler.ChangeState(true);
    }

    private void OnDisable()
    {
        InputsHandler.ChangeState(false);
    }
}
