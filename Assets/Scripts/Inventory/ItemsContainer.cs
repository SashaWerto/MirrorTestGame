using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
    public List<ItemRef> items = new List<ItemRef>();
    public Action OnRefresh;
    public Action OnChanged;
    
    public void AddItem(ItemRef itemRef)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == itemRef.item)
            {
                items[i].count += itemRef.count;
                OnRefresh?.Invoke();
                return;
            }
        }
        items.Add(itemRef);
        OnChanged?.Invoke();
    }

    public void RemoveItem(ItemRef itemRef)
    {
        items.Remove(itemRef);
        OnChanged?.Invoke();
    }
}
[Serializable]
public class ItemRef
{
    public Item item;
    public int count;
}
