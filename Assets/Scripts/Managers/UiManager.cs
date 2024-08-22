using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public List<ItemSlot> itemSlotsList = new List<ItemSlot>();

    //Variables for the Canvas Objects
    public GameObject interactionTextArea; // This will change later

    PlayerController p_playerController;
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
                        print(itemSlotsList[i].GetComponent<ItemSlot>().HasItem + " yayay");
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

        //test area
        interactionTextArea = GameObject.Find("Interaction Text Area");

        

        
    }
    // Update is called once per frame
    void Update()
    {
        //testing - press E button Message
        if (p_playerController.GetCanInteract()) TurnOffAndOnUI(interactionTextArea, true);
        else TurnOffAndOnUI(interactionTextArea, false);

        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = 0; i < itemSlotsList.Count; i++)
            {
                print("Saving");
                SaveSystem.SaveItemSlot(itemSlotsList);
            }

        }
    }
    //Turn On or Off UI element
    void TurnOffAndOnUI(GameObject uiObj, bool value)
    {
        uiObj.SetActive(value);
    }
}
