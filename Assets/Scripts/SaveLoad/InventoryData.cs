using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static InventoryData;

[Serializable]
public class InventoryData
{
    public List<ItemData> itemsData;
    public List<ItemSlotData> itemSlotsData;

    [Serializable]
    public class ItemData
    {
        public int id;
        public string name;
        public string description;
        public string inventoryPortraitPath; // Store path to the sprite
        public string inventoryItemPath; // Store path to the Items
        public bool isItemEquip;
        public float itemDamage;
        
    }
   
    // Constructor to create InventoryData from a list of Items
    public InventoryData(List<Item> itemsList)
    {
        itemsData = new List<ItemData>();
        itemSlotsData = new List<ItemSlotData>();

        foreach (Item item in itemsList)
        {
            ItemData itemData = new ItemData
            {
                id = item.i_ID,
                name = item.i_name,
                description = item.i_description,
                itemDamage = item.i_damage,
                inventoryPortraitPath = AssetDatabase.GetAssetPath(item.i_inventoryPortrait),
                //inventoryItemPath = AssetDatabase.GetAssetPath(item.i_inventoryItem),
                isItemEquip = item.i_isEquiped
            };

            itemsData.Add(itemData);
        }
        

    }
}
