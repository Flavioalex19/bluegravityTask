using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public List<ItemSlot> itemSlotsList = new List<ItemSlot>();
    public Transform MyInventory;
    //Variables for the Canvas Objects
    //Interection Text
    public GameObject interactionTextArea; // This will change later

    //public bool DialgueIsActive = false;
    //Animator animator_DialogueBox;


    public bool isInventoryOn = false;
    Animator animator_inventory;

    PlayerController p_playerController;
    GameManager gm_gameManager;
    private void Awake()
    {
        if (SaveSystem.LoadItemSlot() != null)
        {
            // Load the ItemSlotData
            ItemSlotData loadedData = SaveSystem.LoadItemSlot();

            // Ensure loadedData is not null
            if (loadedData != null)
            {
                // Iterate through the itemSlotsList
                for (int i = 0; i < itemSlotsList.Count; i++)
                {
                    // Ensure we have enough data in the loadedData.ItemSlotsList
                    if (i < loadedData.ItemSlotsList.Count)
                    {
                        // Access the SlotData from loadedData
                        ItemSlotData.SlotData loadedSlotData = loadedData.ItemSlotsList[i];

                        // Update the HasItem field of each ItemSlot with the HasEquipped value
                        itemSlotsList[i].GetComponent<ItemSlot>().HasItem = loadedSlotData.HasEquipped;
                        itemSlotsList[i].GetComponent<ItemSlot>().SlotID = loadedSlotData.SlotIndex;
                        //print(itemSlotsList[i].GetComponent<ItemSlot>().SlotID + " yayay " );

                    }
                }
            }
        }
        else print("No save");

    }
    // Start is called before the first frame update
    void Start()
    {
        p_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator_inventory = GameObject.Find("Inventory Grid Area").GetComponent<Animator>();
        gm_gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //test area
        interactionTextArea = GameObject.Find("Interaction Text Area");

        if(gm_gameManager.gm_IsABattle)isInventoryOn = true;


    }
    // Update is called once per frame
    void Update()
    {
        //testing - press E button Message
        if (p_playerController.GetCanInteract()) TurnOffAndOnUI(interactionTextArea, true);
        else TurnOffAndOnUI(interactionTextArea, false);

        //Testing area
        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = 0; i < itemSlotsList.Count; i++)
            {
                print("Saving " + itemSlotsList[i].SlotID);
                SaveSystem.SaveItemSlot(itemSlotsList);
            }

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOn = !isInventoryOn;
        }
        animator_inventory.SetBool("isOn", isInventoryOn);
       

    }
    public void SetIsInventoryOn()
    {
        isInventoryOn = !isInventoryOn;
    }
    //Turn On or Off UI element
    void TurnOffAndOnUI(GameObject uiObj, bool value)
    {
        uiObj.SetActive(value);
    }
    //Fill item slot list{

}
