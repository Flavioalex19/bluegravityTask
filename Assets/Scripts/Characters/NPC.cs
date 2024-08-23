using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : Interactable
{

    //variables
    [SerializeField] int npc_DialogueIndex;//Index for the lines
    [SerializeField] List<string> npc_Lines = new List<string>();//LInes that the npc will talk
    [SerializeField] List<string> npc_Lines2 = new List<string>();//If The Npc has a second Lines od Dialogue
    [SerializeField] bool hasMoreDialogue = false;
    [SerializeField] bool canProgressStory = false
;
    //Components
    UiManager m_uiManager;
    public DialogueManager m_dialogueManager;
    PlayerController m_playerController;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI _lineText;

    public bool isPlayerInRange = false;//test
    // Start is called before the first frame update
    void Start()
    {
        m_uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        m_dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        dialogueCanvas.SetActive(false);
    }

    private void Update()
    {
        
        // Check for player input (e.g., press 'E' to start dialogue)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            m_playerController.int_isInDialogue = true;
            // Activate the canvas and start the dialogue
            dialogueCanvas.SetActive(true);
            m_dialogueManager.Dialogue(npc_Lines, npc_DialogueIndex, true, _lineText);
            npc_DialogueIndex++;

            if (npc_DialogueIndex >= npc_Lines.Count + 1) 
            {
                npc_DialogueIndex = 0;
                dialogueCanvas.SetActive(false);
                m_playerController.int_isInDialogue = false;
                if (canProgressStory) /*SceneManager.LoadScene(2);*/TrasitionNewLevel.Transition();
                if(hasMoreDialogue) npc_Lines = npc_Lines2;
            }
            
        }
    }
    
    // Trigger to detect when the player enters the NPC's range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            int_player = other.GetComponent<PlayerController>();
            int_canInteract = true;
            int_player.SetCanInteract(int_canInteract);
        }
    }

    // Trigger to detect when the player leaves the NPC's range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // Player is out of range
            dialogueCanvas.SetActive(false); // Deactivate the canvas when the player leaves
            npc_DialogueIndex = 0; // Reset dialogue index

            int_canInteract = false;
            int_player.SetCanInteract(int_canInteract);
            int_player = null;
        }
    }
    
}

    
   

