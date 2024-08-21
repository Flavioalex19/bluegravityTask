using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /*
    private static string path = Application.persistentDataPath + "/player.txt";
    public static void SaveInventory(List<Item> inventoryManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        InventoryData inv_data = new InventoryData(inventoryManager);

        formatter.Serialize(stream, inv_data);
        stream.Close();
    }

    public static InventoryData LoadInventory()
    {
        path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            InventoryData inventoryData = formatter.Deserialize(stream) as InventoryData;
            stream.Close();

            return inventoryData;
        }
        else
        {
            Debug.LogWarning("No save file found" + path);
            return null;
        }

    }

    public static void ClearSaveData()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data cleared successfully.");
        }
        else
        {
            Debug.LogWarning("No save file found to clear.");
        }
    }*/
    private static string path = Application.persistentDataPath + "/player.json";

    public static void SaveInventory(List<Item> inventoryManager)
    {
        InventoryData inv_data = new InventoryData(inventoryManager); // Example data
        string json = JsonUtility.ToJson(inv_data, true); // 'true' for pretty-printing

        File.WriteAllText(path, json);
        Debug.Log("Saving to: " + path);
    }

    public static InventoryData LoadInventory()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            InventoryData inventoryData = JsonUtility.FromJson<InventoryData>(json);
            Debug.Log("Loading from: " + path);
            return inventoryData;
        }
        else
        {
            Debug.LogWarning("No save file found at " + path);
            return null;
        }
    }

    public static void ClearSaveData()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data cleared successfully.");
        }
        else
        {
            Debug.LogWarning("No save file found to clear.");
        }
    }
}
