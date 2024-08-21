using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class InventoryData
{
    public List<ItemData> itemsData;

    [Serializable]
    public class ItemData
    {
        public string name;
        public string description;
        public string inventoryPortraitPath; // Store path to the sprite
        public string inventoryItemPath; // Store path to the GameObject
    }

    // Constructor to create InventoryData from a list of Items
    public InventoryData(List<Item> itemsList)
    {
        itemsData = new List<ItemData>();

        foreach (Item item in itemsList)
        {
            ItemData itemData = new ItemData
            {
                name = item.i_name,
                description = item.i_description,
                inventoryPortraitPath = AssetDatabase.GetAssetPath(item.i_inventoryPortrait),
                inventoryItemPath = AssetDatabase.GetAssetPath(item.i_inventoryItem)
            };

            itemsData.Add(itemData);
        }

    }
}
