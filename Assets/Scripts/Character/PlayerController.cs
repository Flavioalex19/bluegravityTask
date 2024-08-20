using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables
    #region Movement
    Vector3 _move;
    #endregion

    //Components
    Movement c_movement;

    // Start is called before the first frame update
    void Start()
    {
        c_movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Inputs
        //Get input values
        _move = Vector3.zero;
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");
        //Execute movement
        c_movement.Move(_move);
    }
}
