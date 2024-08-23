using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool gm_IsABattle = false;//If we are on the Battle Scene
    public enum BPBattlePhase { PlayerTurn, AITurn }

    [SerializeField] BPBattlePhase bp_CurrentPhase;
    [SerializeField] int bp_TurnCount = 0;
    [SerializeField] bool bp_IsPlayerTurn = true;

    private void Start()
    {
        // Start with the player's turn
        bp_CurrentPhase = BPBattlePhase.PlayerTurn;
        bp_IsPlayerTurn = true;
    }
    private void Update()
    {
        
    }
    public void BattleState()
    {
        if (bp_CurrentPhase == BPBattlePhase.PlayerTurn)
        {
            // Player's turn logic
            Debug.Log("Player's Turn");
            // Example: Wait for player's input and end turn
        }
        else if (bp_CurrentPhase == BPBattlePhase.AITurn)
        {
            // AI's turn logic
            Debug.Log("AI's Turn");
            // Example: AI logic and end turn
        }
    }

    // Call this function to pass the turn
    public void PassTurn()
    {
        bp_TurnCount++;

        if (bp_CurrentPhase == BPBattlePhase.PlayerTurn)
        {
            bp_CurrentPhase = BPBattlePhase.AITurn;
            bp_IsPlayerTurn = false;
        }
        else if (bp_CurrentPhase == BPBattlePhase.AITurn)
        {
            bp_CurrentPhase = BPBattlePhase.PlayerTurn;
            bp_IsPlayerTurn = true;
        }

        BattleState();
    }
}


