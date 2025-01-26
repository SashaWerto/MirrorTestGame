using System;
using System.Collections.Generic;
using UnityEngine;

public class ContainerUi : MonoBehaviour
{
    [Header("References")]
    public ItemsContainer container;
    
    [Header("Preferences")]
    public RectTransform content;
    public GameObject slotPrefab;
    
    private List<Slot> createdSlots = new List<Slot>();

    private void OnEnable()
    {
        container.OnChanged += Refresh;
        container.OnRefresh += RefreshSlots;
    }
    private void Disable()
    {
        container.OnChanged -= Refresh;
        container.OnRefresh -= RefreshSlots;
    }

    public void Refresh()
    {
        foreach (var itemRef in container.items)
        {
            var createdSlotObj = Instantiate(slotPrefab, content);
            createdSlotObj.TryGetComponent<Slot>(out var slot);
            createdSlots.Add(slot);
            slot.Refresh();
        }
    }

    public void RefreshSlots()
    {
        foreach (var slot in createdSlots)
        {
            slot.Refresh();
        }
    }
}
