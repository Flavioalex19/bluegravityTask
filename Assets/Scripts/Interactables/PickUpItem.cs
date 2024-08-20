using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable
{

    [SerializeField] Item so_Item;//Scriptable Object of the item

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
                Destroy(gameObject);//remove the object
            }
        }
    }
}
