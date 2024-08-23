/// <summary>
/// This script made by Flavio Alexandre
/// This Script is related to the Itmes
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    //Variables
    public int i_ID;
    public string i_name;
    public string i_description;
    public bool i_isEquiped;
    public float i_damage;//If has positive value heals, if negative deals damage

    public Sprite i_inventoryPortrait;//Icon that will be displayed at the inventory
    //public GameObject i_inventoryItem;

    
    
}
