using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAi : MonoBehaviour
{
    public GameManager gm_Manager;

    [SerializeField] private List<ItemSlot> bpItemSlots = new List<ItemSlot>();
    [SerializeField] private List<Item> bpItems = new List<Item>();

    [SerializeField] float bp_MaxHP = 100F;
    [SerializeField] float bp_HP;

    [SerializeField] int bp_MaxActionPerTurn = 2;
    [SerializeField] int bp_CurrentActionPerTurn;
    private void Start()
    {
        gm_Manager = GameObject.FindObjectOfType<GameManager>();

        bp_HP = bp_MaxHP;
        bp_CurrentActionPerTurn = bp_MaxActionPerTurn;
    }

    private void Update()
    {
        if(gm_Manager.Bp_CurrentPhase == BPBattlePhase.AITurn )
        {
            ChooseAction();
        }
    }
    // Choose the action 
    public void ChooseAction()
    {
        if (bp_CurrentActionPerTurn > 0)
        {
            // Logic to choose an action - Random
            int action = Random.Range(0, 3);
            print("My Turn");
            /*
            switch (action)
            {
                case 0:
                    Attack();
                    break;
                case 1:
                    Healing();
                    break;
                case 2:
                    Buffing();
                    break;
            }
            */
            switch (action)
            {
                case 0:
                    StartCoroutine(PerformActionWithDelay(Attack));
                    break;
                case 1:
                    StartCoroutine(PerformActionWithDelay(Healing));
                    break;
                case 2:
                    StartCoroutine(PerformActionWithDelay(Buffing));
                    break;
            }
        }
        else
        {
            bp_CurrentActionPerTurn = bp_MaxActionPerTurn;
            gm_Manager.PassTurn();
        }
        
    }
    IEnumerator PerformActionWithDelay(System.Action action)
    {
        action.Invoke(); // Perform the chosen action
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        bp_CurrentActionPerTurn--;
    }

    void Attack()
    {
        Debug.Log("AI attacks!");
    }

    void Healing()
    {
        Debug.Log("AI heals!");
    }

    void Buffing()
    {
        Debug.Log("AI buffs!");
    }
}
