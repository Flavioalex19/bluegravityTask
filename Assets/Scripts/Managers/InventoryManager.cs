using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        ItemsGrid.gameObject.SetActive(false);//testing purposes
    }
   
    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            ItemsGrid.gameObject.SetActive(true);
            //ListItems();
            
            
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
   
}
