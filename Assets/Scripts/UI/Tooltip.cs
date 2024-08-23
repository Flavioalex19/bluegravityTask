using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private void OnMouseEnter()
    {
        print("Enter");
    }
    private void OnMouseExit()
    {
        print("Out");
    }
}
