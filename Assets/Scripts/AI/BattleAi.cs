using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAi : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> bpItemSlots = new List<ItemSlot>();
    [SerializeField] private List<Item> bpItems = new List<Item>();

    // Choose the action for the AI (e.g., attack, heal, buff, etc.)
    public void ChooseAction()
    {
        // Logic to choose an action - Random
        int action = Random.Range(0, 3);

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
    }


    private void Attack()
    {
        Debug.Log("AI attacks!");
    }

    private void Healing()
    {
        Debug.Log("AI heals!");
    }

    private void Buffing()
    {
        Debug.Log("AI buffs!");
    }
}
