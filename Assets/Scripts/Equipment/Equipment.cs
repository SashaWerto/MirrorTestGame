using UnityEngine;
using Mirror;

public class Equipment : NetworkBehaviour
{
    [Header("References")]
    public Transform weaponHolder;
    [Header("TEST")]
    public Item startWeapon;
    public GameObject weaponPrefab;

    private void Update()
    {
        if(!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.K))
        {
            CmdEquip(startWeapon);
        }
    }
    [Command]
    private void CmdEquip(Item item)
    {
        switch (item.itemType)
        {
            case ItemType.weapon:
                GameObject obj = Instantiate(item.prefab, weaponHolder);
                NetworkServer.Spawn(obj);
                break;
        }
    }
}
