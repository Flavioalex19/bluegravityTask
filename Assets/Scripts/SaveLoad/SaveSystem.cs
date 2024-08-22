using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/Inventory.json";
    private static string itemSlotPath = Application.persistentDataPath + "/itemSlot.json";

    #region Inventory
    public static void SaveInventory(List<Item> inventoryManager)
    {
        InventoryData inv_data = new InventoryData(inventoryManager); 
        string json = JsonUtility.ToJson(inv_data, true);

        File.WriteAllText(path, json);
        Debug.Log("Saving to: " + path);
    }
    public static InventoryData LoadInventory()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
            
            return inventoryData;
        }
        else
        {
            Debug.LogWarning("No save file found at " + path);
            return null;
        }
    }
    #endregion

    public static void SaveItemSlot(List<ItemSlot> itemSlot)
    {
        ItemSlotData itemSlotData = new ItemSlotData(itemSlot);
        string json = JsonUtility.ToJson(itemSlotData, true);
        File.WriteAllText(itemSlotPath, json);
        Debug.Log("Saving Slots to: " + itemSlotPath);
    }
   public static ItemSlotData LoadItemSlot()
    {
        if (File.Exists(itemSlotPath))
        {
            string json = File.ReadAllText(itemSlotPath);
            ItemSlotData itemSlotData = JsonUtility.FromJson<ItemSlotData>(json);
            return itemSlotData;
        }
        else
        {
            Debug.LogWarning("No save Slot file found at " + itemSlotPath);
            return null;
        }
    }

    public static void ClearSaveData()
    {
        if (File.Exists(path)|| File.Exists(itemSlotPath))
        {
            File.Delete(path);
            File.Delete(itemSlotPath);
            Debug.Log("Save data cleared successfully.");
        }
        else
        {
            Debug.LogWarning("No save file found to clear.");
        }
    }
}
