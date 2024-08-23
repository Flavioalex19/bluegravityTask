
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreenManager : MonoBehaviour
{
    //Variables
    public bool canStartGame = false;//if the player is allow to start/continue the game
    bool hasASaveGame = false;//if ha any save data
    GameObject pressStartOrContinue;//Depending on whether there is saved data, the message at the beginning will change


    // Start is called before the first frame update
    void Start()
    {
        pressStartOrContinue = GameObject.Find("Press Start Text");
        if(SaveSystem.LoadItemSlot()!=null && SaveSystem.LoadInventory() != null)
        {
            hasASaveGame=true;
        }
        if (hasASaveGame)
        {
            pressStartOrContinue.transform.GetChild(0).gameObject.SetActive(false);
            pressStartOrContinue.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            pressStartOrContinue.transform.GetChild(0).gameObject.SetActive(true);
            pressStartOrContinue.transform.GetChild(1).gameObject.SetActive(false);
        }
        
    }

    public void StartTheGame()
    {
        canStartGame = true;
    }
    
}
