using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BPBattlePhase { PlayerTurn, AITurn, Preparation, Rules, Victory, Defeat }
public class GameManager : MonoBehaviour
{
    public bool gm_IsABattle = false;//If we are on the Battle Scene
    

    public BPBattlePhase Bp_CurrentPhase;


    [SerializeField] int bp_TurnCount = 0;
    [SerializeField] bool bp_IsPlayerTurn = true;
    [SerializeField] GridLayoutGroup EquiBar;
    int isReady = 0;//verify ig the player chooce exactly 3 items

    private void Start()
    {
        if (bp_IsPlayerTurn)
        {
            // Start with the player's turn
            Bp_CurrentPhase = BPBattlePhase.Rules;//Change to rules
            bp_IsPlayerTurn = true;
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
    public void StartPreparationRound()
    {
        Bp_CurrentPhase = BPBattlePhase.Preparation;
    }
    public void StartTheGame()
    {
        for (int i = 0;i< EquiBar.transform.childCount;i++)
        {
            if (EquiBar.transform.GetChild(i).GetComponent<ItemSlot>().HasItem) isReady++;
        }
        if (isReady > 2) Bp_CurrentPhase = BPBattlePhase.PlayerTurn;
        else SceneManager.LoadScene(1);
    }
}


