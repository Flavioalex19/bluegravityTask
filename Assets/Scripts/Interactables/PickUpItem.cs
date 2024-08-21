using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable
{

    [SerializeField] Item so_Item;//Scriptable Object of the item
    InventoryManager inv_inventory;

    private void Start()
    {
        inv_inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();

        //update the correct icon for the inventory
        //so_Item.i_inventoryItem.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = so_Item.i_inventoryPortrait;
        //print(so_Item.i_inventoryItem.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if has a player to interact
        if (int_player != null)
        {
            //Check if t he player is interacting with the object
            if (int_player.GetIsInteracting() == true)
            {
                int_player.SetCanInteract(false);//Player no longer can interact with this object
                int_player.SetIsInteracting(false);//End the interaction with the player
                InventoryManager.Instance.AddToInventory(so_Item);
                Destroy(gameObject);
                /*
                inv_inventory.AddToList(so_Item);
                Destroy(gameObject);//remove the object
                */
            }
        }
    }
}
