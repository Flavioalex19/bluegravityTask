/// <summary>
/// This script made by Flavio Alexandre
/// This Script is related to the Itmes
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    //Variables
    [SerializeField] string i_name;
    [SerializeField] string i_description;

    [SerializeField] Sprite i_inventoryPortrait;//Icon that will be displayed at the inventory


}
