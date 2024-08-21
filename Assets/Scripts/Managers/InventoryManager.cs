using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

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
    /*
    public void AddToList(Item item)
    {
        ItemList.Add(item);
        for (int i = 0; i < ItemsGrid.transform.childCount; i++)
        {
            if (ItemsGrid.transform.GetChild(i).GetComponent<ItemSlot>().IsSlotEmpty)
            {
                Instantiate(item.i_inventoryItem, ItemsGrid.transform.GetChild(i));
                ItemsGrid.transform.GetChild(i).GetComponent<ItemSlot>().IsSlotEmpty = false;
                break;
            }
        }
        //Instantiate(item.i_inventoryItem, ItemsGrid.transform);
    }
    */
    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemsGrid.gameObject.SetActive(true);
            ListItems();
        }
    }
    public void AddToInventory(Item item)
    {
        ItemList.Add(item);
    }
    public void RemoveFromInventory(Item item)
    {
        ItemList.Remove(item);
    }
    public void ListItems()
    {
        foreach (Item item in ItemList)
        {
            GameObject obj = Instantiate(InventoryItemSlot, ItemsGrid.transform);
            Image itemIcon = obj.transform.Find("Item Image").GetComponent<Image>();

            itemIcon.sprite = item.i_inventoryPortrait;
        }
    }
}
