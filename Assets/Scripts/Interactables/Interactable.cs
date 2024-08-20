/// <summary>
/// This script made by Flavio Alexandre
/// This Script responsible for all the interactables of the game
/// here when the player is in reach the interaction can happen
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //Protected Variables
    protected bool int_canInteract = false;//variable for verification-if the player can interact with certain object

    protected PlayerController int_player;//reference for the player controller script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int_player = other.GetComponent<PlayerController>();
            int_canInteract = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        int_canInteract = false;
        int_player = null;
        print(int_canInteract);
    }
}
