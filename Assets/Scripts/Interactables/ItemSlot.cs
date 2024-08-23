using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int SlotID = 0;
    public bool HasItem = false;
    public Sprite ItemSprite;

    public bool IsInBattle = false;

    //Testing awake
    private void Awake()
    {
        
        
    }

    private void Update()
    {
        /*//Check if has an item
        if (transform.childCount == 0) HasItem = false;
        else HasItem = true;
        */
        if (HasItem && transform.childCount > 0)
        {
            //SlotID = transform.GetChild(0).
            ItemSprite = transform.GetChild(0).GetComponent<DragAndDrop>().IconImage.sprite;
            //SlotID = transform.GetChild(0).GetComponent<DragAndDrop>().MyID;
            print(SlotID);
        }
        else 
        {
            ItemSprite = null;
            SlotID = 0;
            
        } 

       

    }
    public void OnDrop(PointerEventData eventData)
    {
        //GameObject droppedObj = eventData.pointerDrag;
        if(transform.childCount == 0)
        {
            DragAndDrop dd_item = eventData.pointerDrag.GetComponent<DragAndDrop>();
            dd_item.dd_parentAfterDrag = transform;
            HasItem = true;
            
            
        }
        /*
        DragAndDrop dd_item = droppedObj.GetComponent<DragAndDrop>();
        dd_item.dd_parentAfterDrag = transform;
        */
    }
    

}
