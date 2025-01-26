using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [Header("References")]
    public Image icon;
    public TextMeshProUGUI countTmp;
    
    [HideInInspector] public ItemRef itemRef;
    
    public void Refresh()
    {
        icon.sprite = itemRef.item.icon;
        countTmp.text = $"{itemRef.count}";
    }
}
