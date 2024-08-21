using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    //Variables for the Canvas Objects
    public GameObject interactionTextArea; // This will change later

    PlayerController p_playerController;

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
        if(p_playerController.GetCanInteract())TurnOffAndOnUI(interactionTextArea, true);
        else TurnOffAndOnUI(interactionTextArea, false);
    }
    //Turn On or Off UI element
    void TurnOffAndOnUI(GameObject uiObj,bool value)
    {
        uiObj.SetActive(value);
    }
}
