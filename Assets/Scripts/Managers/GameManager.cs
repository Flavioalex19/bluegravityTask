using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BPBattlePhase { PlayerTurn, AITurn, Beginning, Rules }
public class GameManager : MonoBehaviour
{
    public bool gm_IsABattle = false;//If we are on the Battle Scene
    

    public BPBattlePhase Bp_CurrentPhase;


    [SerializeField] int bp_TurnCount = 0;
    [SerializeField] bool bp_IsPlayerTurn = true;

    private void Start()
    {
        if (bp_IsPlayerTurn)
        {
            // Start with the player's turn
            Bp_CurrentPhase = BPBattlePhase.PlayerTurn;//Change to rules
            bp_IsPlayerTurn = true;
        }
        
    }
    private void Update()
    {
        
    }
    
    // Call this function to pass the turn
    public void PassTurn()
    {
        bp_TurnCount++;

        if (Bp_CurrentPhase == BPBattlePhase.PlayerTurn)
        {
            Bp_CurrentPhase = BPBattlePhase.AITurn;
            bp_IsPlayerTurn = false;
        }
        else if (Bp_CurrentPhase == BPBattlePhase.AITurn)
        {
            Bp_CurrentPhase = BPBattlePhase.PlayerTurn;
            bp_IsPlayerTurn = true;
        }

    }
}


