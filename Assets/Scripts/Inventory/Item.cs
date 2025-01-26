using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemNull", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Referecnes")]
    public Sprite icon;

    public GameObject prefab;
    [Header("Prefences")]
    public bool isStackable = true;
    public float weight;
    public ItemType itemType;
}
public enum ItemType
{
    basic = 0,
    weapon = 1,
    consumable = 2,
}