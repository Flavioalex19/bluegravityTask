using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ItemSlotData
{

    // List to store the serialized data (SlotData) for each ItemSlot
    public List<SlotData> ItemSlotsList;

    // Inner class representing data for each slot
    [Serializable]
    public class SlotData
    {
        public bool HasEquipped;
    }

    // Constructor that takes a list of ItemSlot objects and converts them to SlotData
    public ItemSlotData(List<ItemSlot> itemSlotsList)
    {
        ItemSlotsList = new List<SlotData>();

        foreach (ItemSlot slot in itemSlotsList)
        {
            SlotData data = new SlotData()
            {
                HasEquipped = slot.HasItem // Assuming HasItem is the correct property for this
            };

            // Add the SlotData to the ItemSlotsList
            ItemSlotsList.Add(data);
        }
    }
}
