using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerNetwork_Setup : NetworkBehaviour
{
    public List<GameObject> disableOnStart;

    private void OnEnable()
    {
        if (isLocalPlayer)
        {
            DisableComponents();
        }
    }
    private void DisableComponents()
    {
        foreach (var obj in disableOnStart)
        {
            obj.SetActive(false);
        }
    }
}
