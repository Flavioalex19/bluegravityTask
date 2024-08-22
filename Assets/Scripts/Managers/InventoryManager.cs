using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] List<ItemSlot> InventorySlotsList = new List<ItemSlot>();//List of avaliable slots
    [SerializeField] List<Item> ItemList = new List<Item>();//List of Items that the player has
    public GridLayoutGroup ItemsGrid;//add later on the start

    //public Transform ItemContent;
    public GameObject InventoryItemSlot;//Slot of the Item

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //print(ItemsGrid.transform.childCount);
        //ItemsGrid.gameObject.SetActive(false);//testing purposes

        //TESTING!!!!!!!!!!!!!!!!!!!!!!
        
        if (SaveSystem.LoadInventory() != null)
        {
            //SaveSystem.LoadInventory();
            InventoryData data = SaveSystem.LoadInventory();
            
            foreach (InventoryData.ItemData itemData in data.itemsData)
            {
                Item item = CreateItemFromData(itemData);

                if (item != null)
                {
                    
                    ItemList.Add(item);
                    item.i_ID = itemData.id;
                    item.i_isEquiped = itemData.isItemEquip;
                    //update the slots with the itens on the inventory
                    for (int i = 0; i < InventorySlotsList.Count; i++)
                    {
                        if (InventorySlotsList[i].transform.childCount == 0 && InventorySlotsList[i].HasItem)
                        {
                            GameObject obj = Instantiate(InventoryItemSlot, InventorySlotsList[i].transform);
                            Image itemIcon = obj.transform.Find("Item Image").GetComponent<Image>();
                            itemIcon.sprite = item.i_inventoryPortrait;
                            break;
                        }
                    }


                }
            }
            
            
            
        }
    }
   
    private void Update()
    {
        //testing -MUST BE ON GAME MANAGER!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            ItemsGrid.gameObject.SetActive(true);
            //ListItems();
            
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveSystem.SaveInventory(ItemList);
            
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            SaveSystem.ClearSaveData();
        }

    }
    public void AddToInventory(Item item)
    {
        //ItemList.Add(item);
        for (int i = 0; i < InventorySlotsList.Count; i++)
        {
            //Check if there if the slot is empty
            if (InventorySlotsList[i].transform.childCount == 0)
            {
                ItemList.Add(item);
                GameObject obj = Instantiate(InventoryItemSlot, InventorySlotsList[i].transform);
                InventorySlotsList[i].GetComponent<ItemSlot>().HasItem = true;
                Image itemIcon = obj.transform.Find("Item Image").GetComponent<Image>();
                itemIcon.sprite = item.i_inventoryPortrait;
                break;
            }
        }
       
    }
    public void RemoveFromInventory(Item item)
    {
        ItemList.Remove(item);
    }
    private Item CreateItemFromData(InventoryData.ItemData itemData)
    {
        Item item = ScriptableObject.CreateInstance<Item>(); 
        item.i_name = itemData.name;
        item.i_description = itemData.description;

        // Load Sprite and GameObject from paths if needed
        item.i_inventoryPortrait = AssetDatabase.LoadAssetAtPath<Sprite>(itemData.inventoryPortraitPath);
        item.i_inventoryItem = AssetDatabase.LoadAssetAtPath<GameObject>(itemData.inventoryItemPath);

        return item;
    }
    
}
