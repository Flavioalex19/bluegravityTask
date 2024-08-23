using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables
    #region Movement Variables
    public Vector3 _move;
    #endregion

    #region Interaction Variables
    public bool int_canInteract = false;
    public bool int_isInteracting = false;
    public bool int_isInDialogue = false;
    #endregion

    //Components
    Movement c_movement;
    GameManager gm_Manager;

    // Start is called before the first frame update
    void Start()
    {
        c_movement = GetComponent<Movement>();
        gm_Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        //Interactions
        #region Interactions
        //Item Interactions
        if (int_canInteract && Input.GetKeyDown(KeyCode.E))  int_isInteracting = true;
        #endregion
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (int_isInDialogue == false)
        {
            //Movement Inputs
            //Get input values
            _move = Vector3.zero;
            _move.x = Input.GetAxis("Horizontal");
            _move.y = Input.GetAxis("Vertical");
            //Execute movement
            c_movement.Move(_move);
        }
        
    }

    //Get & Set
    public bool GetCanInteract() { return int_canInteract; }
    public void SetCanInteract(bool value) { int_canInteract=value; }
    public bool GetIsInteracting() {  return int_isInteracting; }
    public void SetIsInteracting(bool value) {  int_isInteracting=value; }
    public Vector3 GetMove() { return _move; }

}
